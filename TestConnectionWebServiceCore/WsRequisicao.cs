using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceCore
{
    public class WsRequisicao
    {
        public string ExecutarRequisicao(string urlWebService, string userAgent, string contentType, Dictionary<string, string> parametros, 
            MetodosWebService method, string body, string usuarioWebService, string senhaWebService)
        {
            WsConexao ws = new WsConexao();

            urlWebService += "?";

            if (parametros != null && parametros.Keys != null)
            {
                foreach (var param in parametros)
                {
                    urlWebService += param.Key + "=" + param.Value + "&";
                }
            }

            urlWebService = urlWebService.Substring(0, urlWebService.Length - 1);

            return ws.Executar(urlWebService, userAgent, contentType, method, body, usuarioWebService, senhaWebService);
        }
    }
}