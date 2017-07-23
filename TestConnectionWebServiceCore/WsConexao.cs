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
        public string Executar(string urlWebService, string userAgent, string contentType, MetodosWebService method, 
            string body, string usuarioWebService, string senhaWebService)
        {
            string result = "";

            try
            {
                var httpResquest = (HttpWebRequest)WebRequest.Create(urlWebService);
                httpResquest.Method = method.ToString();
                httpResquest.ContentType = contentType;

                if(!string.IsNullOrEmpty(userAgent))
                    httpResquest.UserAgent = userAgent;

                if(!string.IsNullOrEmpty(usuarioWebService) && !string.IsNullOrEmpty(senhaWebService))
                {
                    NetworkCredential credential = new NetworkCredential();
                    credential.UserName = usuarioWebService.Trim();
                    credential.Password = senhaWebService.Trim();

                    httpResquest.Credentials = credential;
                }

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
    }
}
