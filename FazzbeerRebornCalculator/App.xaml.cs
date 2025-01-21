
namespace FazzbeerRebornCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage())
            {
                MinimumWidth = 400,
                MinimumHeight = 400,
            };


        }
    }
}
