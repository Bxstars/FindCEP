using System.Net;
using Newtonsoft.Json;
using FindCEP.Serviços.Modelo;

namespace FindCEP.Serviços
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

                WebClient wc = new WebClient();
                string Conteudo = wc.DownloadString(NovoEnderecoURL);
                Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

                return end.cep == null ? null : end;
  
        }
    }
}
