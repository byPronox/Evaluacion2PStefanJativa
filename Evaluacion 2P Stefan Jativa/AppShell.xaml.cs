namespace Evaluacion_2P_Stefan_Jativa
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.Pagina2), typeof(Views.Pagina2));
        }
    }
}
