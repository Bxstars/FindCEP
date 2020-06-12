using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FindCEP.Serviços.Modelo;
using FindCEP.Serviços;
using Xamarin.Essentials;

namespace FindCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }
        private void BuscarCEP(object sender, EventArgs args)
        {

            if (Xamarin.Essentials.Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
               
                DisplayAlert("No Internet", "", "Ok"); 

                return;
            }
            string cep = CEP.Text.Trim();  //Em UWP validar valores nulos

            if (isValidCEP(cep))    
            {
               try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                    RESULTADO.Text = string.Format("Endereço : {0}\r\nBairro : {1}\r\nCompl. : {2}\r\nCidade : {3} - {4}", end.logradouro, end.bairro, end.complemento ,end.localidade, end.uf );
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

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep == "")
            {
                DisplayAlert("Erro: ", "Informe o CEP!", "Ok");

                valido = false;
            }
            
            else if (cep.Length != 8)
            {
                DisplayAlert("Erro: CEP inválido!", " O CEP deve conter 8 caracteres.", "Ok");

                valido = false;
            }

            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro: CEP inválido!", "O CEP deve ser composto apenas por números", "Ok");

                valido = false;
            }

            return valido;
        }

    }
}
