namespace Proyect.Views;

public partial class ConceptosBasicosPage : ContentPage
{
    public ConceptosBasicosPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        
        if (BindingContext is ViewModels.ConceptosBasicosViewModel vm)
        {
            vm.VerificarBloqueo();
        }
    }
}