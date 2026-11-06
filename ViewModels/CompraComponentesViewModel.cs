using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using Firebase.Database.Query;
using Proyect.Models;
using System.Collections.ObjectModel;

namespace Proyect.ViewModels
{
    public partial class CompraComponentesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ComponenteTiendaModel> tiendas;

        [ObservableProperty]
        private bool isBusy;

        public CompraComponentesViewModel()
        {
            _ = CargarTiendasDesdeFirebaseAsync();
        }

        private async Task CargarTiendasDesdeFirebaseAsync()
        {
            IsBusy = true;

            try
            {
                var firebaseClient = new FirebaseClient("https://appedu-a8fd0-default-rtdb.firebaseio.com/");

                var resultadoFirebase = await firebaseClient
                    .Child("CompraComponentes")
                    .OnceAsync<ComponenteTiendaModel>();

                var listaTiendas = resultadoFirebase.Select(item => new ComponenteTiendaModel
                {
                    Nombre = item.Object.Nombre,
                    Descripcion = item.Object.Descripcion,
                    Imagen = item.Object.Imagen,
                    Tipo = item.Object.Tipo,
                    Link = item.Object.Link
                }).ToList();

                if (listaTiendas == null || listaTiendas.Count == 0)
                {
                    await Shell.Current.DisplayAlert("Aviso", "No se encontraron lugares de compra disponibles.", "OK");
                    return;
                }

                Tiendas = new ObservableCollection<ComponenteTiendaModel>(listaTiendas);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudieron cargar los datos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task AbrirEnlaceAsync(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    await Launcher.Default.OpenAsync(new Uri(url));
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo abrir el enlace: " + ex.Message, "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Aviso", "Este lugar no cuenta con un enlace disponible.", "OK");
            }
        }
    }
}