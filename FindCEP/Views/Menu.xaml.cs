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
            Detail = new NavigationPage(new BuscaCEP());
        }
		private void GoBuscaLogradouro(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new BuscaLogradouro());
			IsPresented = false;
		}
	}
}