using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindCEP
{
    [ XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static Theme AppTheme { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new BuscaCEP();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public enum Theme
        {
            Light,
            Dark
        }
    }
}
