using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;
using Proyect.Models;
using System.Collections.ObjectModel;

namespace Proyect.ViewModels
{
    public partial class EvaluacionViewModel2 : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PreguntaModel> preguntas;

        [ObservableProperty]
        private bool isBusy;

        public EvaluacionViewModel2()
        {
            _ = CargarPreguntasDesdeFirebaseAsync();
        }

        private async Task CargarPreguntasDesdeFirebaseAsync()
        {
            IsBusy = true;

            try
            {
                var firebaseClient = new FirebaseClient("https://appedu-a8fd0-default-rtdb.firebaseio.com/");

                // ⚠️ APUNTAMOS AL NUEVO NODO DE FIREBASE
                var resultadoFirebase = await firebaseClient
                    .Child("PreguntasTema2")
                    .OnceAsync<PreguntaModel>();

                var poolTotal = resultadoFirebase.Select(item => new PreguntaModel
                {
                    Enunciado = item.Object.Enunciado,
                    Opciones = item.Object.Opciones,
                    respuestaCorrecta = item.Object.respuestaCorrecta
                }).ToList();

                if (poolTotal == null || poolTotal.Count == 0)
                {
                    await Shell.Current.DisplayAlert("Aviso", "No se encontraron preguntas para este tema.", "OK");
                    return;
                }

                // Selección aleatoria de 20 preguntas (o las que existan si hay menos)
                int cantidadATomar = Math.Min(20, poolTotal.Count);
                var seleccionadas = poolTotal
                    .OrderBy(x => Guid.NewGuid())
                    .Take(cantidadATomar)
                    .ToList();

                Preguntas = new ObservableCollection<PreguntaModel>(seleccionadas);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudieron cargar las preguntas: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task FinalizarEvaluacionAsync()
        {
            int aciertos = 0;

            foreach (var p in Preguntas)
            {
                if (p.IndiceSeleccionado == p.respuestaCorrecta)
                {
                    aciertos++;
                }
            }

            // Regla de aprobación: 17 o más aciertos
            if (aciertos >= 17)
            {
                // ⚠️ GUARDAMOS UNA PREFERENCIA DIFERENTE PARA ESTE NIVEL
                Preferences.Set("Tema3Desbloqueado", true);

                await Shell.Current.DisplayAlert("¡Felicidades!", $"Aprobaste con {aciertos}/{Preguntas.Count} aciertos. ¡Siguientes temas desbloqueados!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Evaluación No Superada", $"Obtuviste {aciertos}/{Preguntas.Count} aciertos. Necesitas al menos 17 para avanzar.", "Reintentar");
                _ = CargarPreguntasDesdeFirebaseAsync();
            }
        }
    }
}