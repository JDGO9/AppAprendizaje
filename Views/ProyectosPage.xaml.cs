namespace Proyect.Views;

public partial class ProyectosPage : ContentPage
{
    public ProyectosPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.ProyectosViewModel();
    }
}