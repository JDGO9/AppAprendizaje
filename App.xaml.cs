using Microsoft.Extensions.DependencyInjection;

namespace Proyect;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}