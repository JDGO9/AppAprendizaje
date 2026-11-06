using Proyect.ViewModels;

namespace Proyect.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

       
        BindingContext = new ViewModels.DashboardViewModel();
    }
}