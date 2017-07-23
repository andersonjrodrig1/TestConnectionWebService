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
        private WebProxy Proxy { get; set; }

        public PaginaBO(string urlWebService, string usuarioWebService, string senhaWebService)
        {
            this.urlWebService = urlWebService;
            this.usuarioWebService = usuarioWebService;
            this.senhaWebService = senhaWebService;
            this.Proxy = null;
        }

        public string BuscarPagina(string userAgent, string contentType, string body)
        {
            string resultado = "";

            PaginaDAO paginaDao = new PaginaDAO(urlWebService, usuarioWebService, senhaWebService);
            resultado = paginaDao.BuscarPaginas(userAgent, contentType, body);

            return resultado;
        }

        public List<Pagina> ConverterPaginas(JObject objeto)
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
