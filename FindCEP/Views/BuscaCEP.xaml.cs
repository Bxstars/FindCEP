using System;
using Xamarin.Forms;
using FindCEP.Serviços.Modelo;
using FindCEP.Serviços;
using Xamarin.Essentials;

namespace FindCEP
{
    public partial class BuscaCEP : ContentPage
    {
        public BuscaCEP()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

            StatusConexao();

            string cep = string.Empty;

            if (CEP.Text != null)
            {
                cep = CEP.Text.Trim();
            }

            if (isValidCEP(cep))
            {
                try
                {

                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço : {0}\r\nBairro : {1}\r\nCompl. : {2}\r\nCidade : {3} - {4}", end.logradouro, end.bairro, end.complemento, end.localidade, end.uf);
                    }

                    else
                    {
                        DisplayAlert("Erro: ", "O endereço não foi encontrado para o CEP informado " + cep, "Ok");
                    }

                }

                catch (Exception e)
                {
                    DisplayAlert("Erro Crítico: ", e.Message, "Ok");
                }
            }
        }

        public bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep == "")
            {
                DisplayAlert("Informe o CEP!", "", "Ok");

                valido = false;
            }

             if (cep.Length != 8 || cep.Length >8)
            {
                DisplayAlert("Alerta: ", " O CEP deve conter 8 caracteres.", "Ok");

                valido = false;
            }

            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Alerta: CEP inválido!", "", "Ok");

                valido = false;
            }

            return valido;
        }

        public void StatusConexao() //Verifica a conexão com a internet 
        {
            if (Xamarin.Essentials.Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("No Internet", "", "Ok");
                return;
            }
        }

    }
}
