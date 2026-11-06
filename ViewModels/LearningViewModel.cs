using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Views;

namespace Proyect.ViewModels
{
    public partial class LearningViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task ConceptosBasicosAsync()
        {
            await Shell.Current.GoToAsync(nameof(ConceptosBasicosPage));
        }

        [RelayCommand]

        private async Task ComponentesAsync()
        {
            await Shell.Current.DisplayAlert("Tema", "Abriendo Componentes...", "OK");
        }

        [RelayCommand]
        private async Task AnalogicaAsync()
        {
            await Shell.Current.DisplayAlert("Tema", "Abriendo Electrónica Analógica...", "OK");
        }

        [RelayCommand]
        private async Task DigitalAsync()
        {
            await Shell.Current.DisplayAlert("Tema", "Abriendo Electrónica Digital...", "OK");
        }

        [RelayCommand]
        private async Task RegresarAsync()
        {
            // Vuelve a la pantalla anterior (al Dashboard)
            await Shell.Current.GoToAsync("..");
        }
       
    }
}