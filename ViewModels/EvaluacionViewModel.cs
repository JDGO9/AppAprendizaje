using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.Storage;
using Firebase.Database;
using Firebase.Database.Query;

namespace Proyect.ViewModels
{
    public partial class EvaluacionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PreguntaModel> preguntas;

        [ObservableProperty]
        private bool isBusy;

        public EvaluacionViewModel()
        {
            // Llamamos al método asíncrono para cargar desde Firebase al abrir la vista
            _ = CargarPreguntasDesdeFirebaseAsync();
        }

        private async Task CargarPreguntasDesdeFirebaseAsync()
        {
            IsBusy = true;

            try
            {
                // 1. Conéctate a tu Realtime Database (REEMPLAZA ESTA URL CON LA TUYA DE FIREBASE)
                var firebaseClient = new FirebaseClient("https://appedu-a8fd0-default-rtdb.firebaseio.com/");

                // 2. Obtenemos todas las preguntas del nodo "Preguntas" en Firebase
                var resultadoFirebase = await firebaseClient
                    .Child("Preguntas")
                    .OnceAsync<PreguntaModel>();

                // 3. Mapeamos los datos que vienen de la nube a nuestra lista local
                var poolTotal = resultadoFirebase.Select(item => new PreguntaModel
                {
                    Enunciado = item.Object.Enunciado,
                    Opciones = item.Object.Opciones,
                    respuestaCorrecta = item.Object.respuestaCorrecta
                }).ToList();

                if (poolTotal == null || poolTotal.Count == 0)
                {
                    await Shell.Current.DisplayAlert("Aviso", "No se encontraron preguntas en Firebase.", "OK");
                    return;
                }

                // 4. Mezclamos aleatoriamente con LINQ y tomamos EXACTAMENTE 20 (o las que haya si hay menos de 20)
                int cantidadATomar = Math.Min(20, poolTotal.Count);
                var seleccionadas = poolTotal
                    .OrderBy(x => Guid.NewGuid())
                    .Take(cantidadATomar)
                    .ToList();

                Preguntas = new ObservableCollection<PreguntaModel>(seleccionadas);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error de Conexión", $"No se pudieron cargar las preguntas: {ex.Message}", "OK");
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
                // Comparamos directamente el índice numérico seleccionado en el Picker con el de Firebase
                if (p.IndiceSeleccionado == p.respuestaCorrecta)
                {
                    aciertos++;
                }
            }

            // REGLA: Si saca 17 o más, aprueba. Si no, reprueba.
            if (aciertos >= 15)
            {
                Preferences.Set("TemaSiguienteDesbloqueado", true);
                await Shell.Current.DisplayAlert("¡Felicidades!", $"Aprobaste con {aciertos}/{Preguntas.Count} aciertos. ¡Siguientes temas desbloqueados!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Evaluación No Superada", $"Obtuviste {aciertos}/{Preguntas.Count} aciertos. Necesitas al menos 15 para avanzar. ¡Vuelve a intentarlo!", "Reintentar");

                // Reiniciamos cargando otras preguntas aleatorias
                _ = CargarPreguntasDesdeFirebaseAsync();
            }
        }
    }
}