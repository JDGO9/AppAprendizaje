using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Database;
using Firebase.Database.Query;
using Proyect.Models;
using System.Collections.ObjectModel;

namespace Proyect.ViewModels
{
    
    [QueryProperty(nameof(NodoFirebase), "nodo")]
    public partial class ProyectosViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ProyectoModel> proyectos;

        [ObservableProperty]
        private bool isBusy;

        private string nodoFirebase;
        public string NodoFirebase
        {
            get => nodoFirebase;
            set
            {
                nodoFirebase = value;
                if (!string.IsNullOrEmpty(nodoFirebase))
                {
                    _ = CargarProyectosDesdeFirebaseAsync(nodoFirebase);
                }
            }
        }

        private async Task CargarProyectosDesdeFirebaseAsync(string nombreNodo)
        {
            IsBusy = true;

            try
            {
                var firebaseClient = new FirebaseClient("https://appedu-a8fd0-default-rtdb.firebaseio.com/");

                // Descarga dinámicamente usando el nodo que le pasamos por parámetro
                var resultadoFirebase = await firebaseClient
                    .Child(nombreNodo)
                    .OnceAsync<ProyectoModel>();

                var listaProyectos = resultadoFirebase.Select(item => new ProyectoModel
                {
                    Titulo = item.Object.Titulo,
                    Descripcion = item.Object.Descripcion,
                    Autor = item.Object.Autor,
                    Imagen = item.Object.Imagen,
                    Link = item.Object.Link
                }).ToList();

                if (listaProyectos == null || listaProyectos.Count == 0)
                {
                    await Shell.Current.DisplayAlert("Aviso", "No se encontraron proyectos para este nivel.", "OK");
                    return;
                }

                Proyectos = new ObservableCollection<ProyectoModel>(listaProyectos);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudieron cargar los proyectos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}