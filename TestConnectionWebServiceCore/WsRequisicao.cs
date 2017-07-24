using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceCore
{
    public class WsRequisicao
    {
        private string urlWebService { get; set; }
        private string usuarioWebService { get; set; }
        private string senhaWebService { get; set; }
        private WebProxy Proxy;

        public WsRequisicao(string urlWebService, string usuarioWebService, string senhaWebService)
        {
            this.urlWebService = urlWebService;
            this.usuarioWebService = usuarioWebService;
            this.senhaWebService = senhaWebService;
            this.Proxy = null;
        }

        public string ExecutarRequisicao(string userAgent, string contentType, Dictionary<string, string> parametros, MetodosWebService method, string body, string headerUsuario = null, string headerSenha = null)
        {
            WsConexao ws = new WsConexao(urlWebService, usuarioWebService, senhaWebService);
            WebHeaderCollection header = null;

            if (!string.IsNullOrEmpty(headerUsuario) && !string.IsNullOrEmpty(headerSenha))
                header = AutenticarHeader(headerUsuario, usuarioWebService, headerSenha, senhaWebService);

            urlWebService += "?";

            if (parametros != null && parametros.Keys != null)
            {
                foreach (var param in parametros)
                {
                    urlWebService += param.Key + "=" + param.Value + "&";
                }
            }

            urlWebService = urlWebService.Substring(0, urlWebService.Length - 1);

            return ws.Executar(userAgent, contentType, method, header, body);
        }

        private WebHeaderCollection AutenticarHeader(string headerUsuario, string usuario, string headerSenha, string senha)
        {
            WebHeaderCollection header = new WebHeaderCollection();
            header.Add(headerUsuario, usuario);
            header.Add(headerSenha, senha);

            return header;
        }
    }
}