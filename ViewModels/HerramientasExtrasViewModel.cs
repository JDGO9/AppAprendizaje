using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Views;

namespace Proyect.ViewModels
{
    public partial class HerramientasExtrasViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task VideosRefuerzoAsync()
        {
            try
            {
                // Reemplaza con el enlace de tu canal de YouTube o lista de reproducción
                await Launcher.Default.OpenAsync(new Uri("https://www.youtube.com"));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo abrir el enlace: " + ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task CompraComponentesAsync()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(CompraComponentesPage));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo abrir el enlace: " + ex.Message, "OK");
            }
        }
    }
}