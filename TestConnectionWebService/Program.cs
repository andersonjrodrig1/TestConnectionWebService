using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://jsonplaceholder.typicode.com/posts";
            string contentType = "application/x-www-form-urlencoded";
            string userAgent = "RequisicaoWebDemo";
            string body = "";
            string usuario = "";
            string senha = "";

            string response = ExecutarRequisicao(url, userAgent, contentType, null, MetodosWebService.GET, body, usuario, senha);
            response = "{d:" + response + "}";

            JObject objeto = ConverterJsonParaObject(response);
            var lista = RetornarPaginas(objeto);

            Console.Write(lista[0].title);

            Console.ReadKey();
        }

        static string ExecutarRequisicao(string url, string userAgent, string contentType, Dictionary<string, string> parametros,
            MetodosWebService method, string body, string usuario, string senha)
        {
            url += "?";

            if (parametros != null && parametros.Keys != null)
            {
                foreach (var param in parametros)
                {
                    url += param.Key + "=" + param.Value + "&";
                }
            }

            url = url.Substring(0, url.Length - 1);

            return Executar(url, userAgent, contentType, method, body, usuario, senha);
        }

        private static string Executar(string url, string userAgent, string contentType, MetodosWebService method, string body, string usuario, string senha)
        {
            string result = "";

            try
            {
                var httpResquest = (HttpWebRequest)WebRequest.Create(url);
                httpResquest.Method = method.ToString();
                httpResquest.ContentType = contentType;
                httpResquest.UserAgent = userAgent;

                if (method == MetodosWebService.POST && !string.IsNullOrEmpty(body))
                {
                    var request = new StreamWriter(httpResquest.GetRequestStream());
                    request.Write(body);
                    request.Flush();
                    request.Close();
                }

                var response = httpResquest.GetResponse();
                var streamDados = response.GetResponseStream();
                var reader = new StreamReader(streamDados);

                result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        private static List<Pagina> RetornarPaginas(JObject objeto)
        {
            var lista = new List<Pagina>();

            if (objeto != null && objeto.ToString().Contains("d") && ((Newtonsoft.Json.Linq.JContainer)(objeto["d"])).Count > 0)
            {
                for (int i = 0; i < ((Newtonsoft.Json.Linq.JContainer)(objeto["d"])).Count; i++)
                {
                    Pagina pag = new Pagina();
                    pag.userId = Convert.ToInt32(objeto["d"][i]["userId"].ToString());
                    pag.id = Convert.ToInt32(objeto["d"][i]["id"].ToString());
                    pag.title = objeto["d"][i]["title"].ToString();
                    pag.body = objeto["d"][i]["body"].ToString();

                    lista.Add(pag);
                }
            }

            return lista;
        }

        private static JObject ConverterJsonParaObject(string json)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(json);

            return obj;
        }
    }

    class Pagina
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    enum MetodosWebService
    {
        GET,
        POST,
        PUT,
        DELETE
    };
}
