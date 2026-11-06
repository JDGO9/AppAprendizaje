
using Proyect.Views;

namespace Proyect
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EvaluacionPage), typeof(EvaluacionPage));
            Routing.RegisterRoute(nameof(LearningPage), typeof(LearningPage));
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ConceptosBasicosPage), typeof(ConceptosBasicosPage));
            Routing.RegisterRoute(nameof(ConceptosBasicosPage2), typeof(ConceptosBasicosPage2));
            Routing.RegisterRoute(nameof(EvaluacionPage2), typeof(EvaluacionPage2));
            Routing.RegisterRoute(nameof(MenuNivelesPage), typeof(MenuNivelesPage));
            Routing.RegisterRoute(nameof(ProyectosPage), typeof(ProyectosPage));
            Routing.RegisterRoute(nameof(HerramientasExtrasPage), typeof(HerramientasExtrasPage));
            Routing.RegisterRoute(nameof(CompraComponentesPage), typeof(CompraComponentesPage));
            Routing.RegisterRoute("LoginPage", typeof(Views.LoginPage));

        }
    }
}
