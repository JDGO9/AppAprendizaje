namespace Proyect.Views;

public partial class ConceptosBasicosPage2 : ContentPage
{
    public ConceptosBasicosPage2()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

       
        if (BindingContext is ViewModels.ConceptosBasicosViewModel2 vm)
        {
            vm.VerificarBloqueo();
        }
    }
}