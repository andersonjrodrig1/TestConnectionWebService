using System.Collections.Generic;
using System.Net;
using TestConnectionWebServiceCore;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceDAO
{
    public class PaginaDAO
    {
        private string urlWebService { get; set; }
        private string usuarioWebService { get; set; }
        private string senhaWebService { get; set; }
        private WebProxy Proxy { get; set; }

        public PaginaDAO(string urlWebService, string usuarioWebService, string senhaWebService)
        {
            this.urlWebService = urlWebService;
            this.usuarioWebService = usuarioWebService;
            this.senhaWebService = senhaWebService;
            this.Proxy = null;
        }

        public string BuscarPaginas(string userAgent, string contentType, string body)
        {
            WsRequisicao ws = new WsRequisicao(urlWebService, usuarioWebService, senhaWebService);

            string resultado = ws.ExecutarRequisicao(userAgent, contentType, null, MetodosWebService.GET, body);

            return resultado;
        }
    }
}
