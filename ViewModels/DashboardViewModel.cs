using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Views;

namespace Proyect.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task AprendizajeAsync()
        {
            await Shell.Current.GoToAsync(nameof(LearningPage));
        }

        [RelayCommand]
        private async Task EstadisticasAsync()
        {
            await Shell.Current.GoToAsync(nameof(MenuNivelesPage));
        }

        [RelayCommand]
        private async Task AjustesAsync()
        {
            await Shell.Current.GoToAsync(nameof(HerramientasExtrasPage));
        }

        [RelayCommand]
        private async Task LogoutAsync()
        {
            bool confirmar = await Shell.Current.DisplayAlert("Cerrar Sesión", "¿Estás seguro de salir?", "Sí", "No");
            if (confirmar)
            {
                
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }
    }
}