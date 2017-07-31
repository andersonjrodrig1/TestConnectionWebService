using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceCore
{
    public class WsConexao
    {
        private string urlWebService { get; set; }
        private string usuarioWebService { get; set; }
        private string senhaWebService { get; set; }
        private WebProxy proxy;

        public WsConexao(string urlWebService, string usuarioWebService, string senhaWebService)
        {
            this.urlWebService = urlWebService;
            this.usuarioWebService = usuarioWebService;
            this.senhaWebService = senhaWebService;
            this.proxy = null;
        }

        public string Executar(string userAgent, string contentType, MetodosWebService method, WebHeaderCollection header, string body, bool isBasic, bool isHeader)
        {
            string result = "";

            try
            {
                var httpResquest = (HttpWebRequest)WebRequest.Create(urlWebService);
                httpResquest.Method = method.ToString();

                if(!string.IsNullOrEmpty(contentType))
                    httpResquest.ContentType = contentType;

                if(!string.IsNullOrEmpty(userAgent))
                    httpResquest.UserAgent = userAgent;

                if (isBasic)
                {
                    SetAutenticationBasic(httpResquest, usuarioWebService, senhaWebService);
                }
                else if (isHeader && header != null)
                {
                    httpResquest.Headers = header;
                }
                else if (!string.IsNullOrEmpty(usuarioWebService) && !string.IsNullOrEmpty(senhaWebService))
                {
                    NetworkCredential credential = new NetworkCredential();
                    credential.UserName = usuarioWebService.Trim();
                    credential.Password = senhaWebService.Trim();

                    httpResquest.Credentials = credential;
                }

                if (proxy != null)
                    httpResquest.Proxy = proxy;

                if (method == MetodosWebService.POST && !string.IsNullOrEmpty(body))
                {
                    var request = new StreamWriter(httpResquest.GetRequestStream());
                    request.Write(body);
                    request.Flush();
                    request.Close();
                }

                using (var response = httpResquest.GetResponse())
                {
                    var streamDados = response.GetResponseStream();
                    var reader = new StreamReader(streamDados);

                    result = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        private static void SetAutenticationBasic(HttpWebRequest httpRequest, string usuario, string senha)
        {
            httpRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(usuario + ":" + senha));
        }
    }
}
