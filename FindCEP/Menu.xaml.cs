using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindCEP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuDetail());
        }
		private void GoBuscaCEP(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new BuscaCEP());
			IsPresented = false;
		}

		private void GoBuscaLogradouro(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new BuscaLogradouro());
			IsPresented = false;
		}

		private void GoBuscaBairro(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new BuscaBairro());
			IsPresented = false;
		}
	}
}