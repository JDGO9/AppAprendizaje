using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Views;
using CommunityToolkit.Mvvm.Input;
using Proyect.Views;

namespace Proyect.ViewModels
{
    public partial class MenuNivelesViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task IrPrincipianteAsync()
        {
            
            await Shell.Current.GoToAsync($"{nameof(ProyectosPage)}?nodo=ProyectosPrincipiante");
        }

        [RelayCommand]
        private async Task IrIntermedioAsync()
        {
            
            await Shell.Current.GoToAsync($"{nameof(ProyectosPage)}?nodo=ProyectosIntermedio");
        }

        [RelayCommand]
        private async Task IrAvanzadoAsync()
        {

            await Shell.Current.GoToAsync($"{nameof(ProyectosPage)}?nodo=ProyectosAvanzado");
        }
    }
}