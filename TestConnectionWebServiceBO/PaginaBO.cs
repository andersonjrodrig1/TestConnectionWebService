using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using TestConnectionWebServiceDAO;
using TestConnectionWebServiceEntity;
using TestConnectionWebServiceUtil;

namespace TestConnectionWebServiceBO
{
    public class PaginaBO
    {
        private string urlWebService { get; set; }
        private string usuarioWebService { get; set; }
        private string senhaWebService { get; set; }
        private WebProxy proxy { get; set; }

        public PaginaBO(string urlWebService, string usuarioWebService, string senhaWebService)
        {
            this.urlWebService = urlWebService;
            this.usuarioWebService = usuarioWebService;
            this.senhaWebService = senhaWebService;
            this.proxy = null;
        }

        public string BuscarPagina(string userAgent, string contentType, string body)
        {
            string resultado = "";

            PaginaDAO paginaDao = new PaginaDAO(urlWebService, usuarioWebService, senhaWebService);
            resultado = paginaDao.BuscarPaginas(userAgent, contentType, body);

            return resultado;
        }

        public string BuscarDadosWebService(string userAgent, string contentType, string body, int metodo, string headerkey, string headerValue, bool isHeader, bool isBasic)
        {
            Dictionary<string, string> dadosAutentica = null;
            PaginaDAO paginaDAO = new PaginaDAO(urlWebService, usuarioWebService, senhaWebService);

            if (isHeader)
            {
                dadosAutentica = new Dictionary<string, string>();
                dadosAutentica.Add(usuarioWebService, senhaWebService);
                dadosAutentica.Add(headerkey, headerValue);
            }

            if (!string.IsNullOrEmpty(body))
            {
                //TODO: montagem do body em formato json
            }

            MetodosWebService method = this.BuscarMetodoWebService(metodo);

            return paginaDAO.BuscarDadosWebService(userAgent, contentType, body, method, dadosAutentica, isBasic, isHeader);
        }

        private MetodosWebService BuscarMetodoWebService(int valor)
        {
            if(valor == 1)
                return MetodosWebService.POST;
            else if(valor == 2)
                return MetodosWebService.PUT;
            else if(valor == 3)
                return MetodosWebService.DELETE;
            else
                return MetodosWebService.GET;
        }

        private List<Pagina> ConverterPaginas(JObject objeto)
        {
            var paginas = new List<Pagina>();

            if (objeto != null && objeto.ToString().Contains("d") && ((Newtonsoft.Json.Linq.JContainer)(objeto["d"])).Count > 0)
            {
                for (int i = 0; i < ((Newtonsoft.Json.Linq.JContainer)(objeto["d"])).Count; i++)
                {
                    Pagina pag = new Pagina();
                    pag.userId = Convert.ToInt32(objeto["d"][i]["userId"].ToString());
                    pag.id = Convert.ToInt32(objeto["d"][i]["id"].ToString());
                    pag.title = objeto["d"][i]["title"].ToString();
                    pag.body = objeto["d"][i]["body"].ToString();

                    paginas.Add(pag);
                }
            }

            return paginas;
        }
    }
}
