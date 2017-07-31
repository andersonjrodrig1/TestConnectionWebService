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

        public string ExecutarRequisicao(string userAgent, string contentType, MetodosWebService method, string body, Dictionary<string,string> dadosAutenticacao, bool isBasic, bool isHeader)
        {
            WsConexao ws = new WsConexao(urlWebService, usuarioWebService, senhaWebService);
            WebHeaderCollection header = null;

            if (isHeader && dadosAutenticacao.Keys.Count > 0)
                header = MontarHeader(dadosAutenticacao["keyUser1"], dadosAutenticacao["valuePass1"], dadosAutenticacao["keyUser2"], dadosAutenticacao["valuePass2"]);

            return ws.Executar(userAgent, contentType, method, header, body, isBasic, isHeader);
        }

        private WebHeaderCollection MontarHeader(string headerUsuario, string usuario, string headerSenha, string senha)
        {
            WebHeaderCollection header = new WebHeaderCollection();
            header.Add(headerUsuario, usuario);
            header.Add(headerSenha, senha);

            return header;
        }
    }
}