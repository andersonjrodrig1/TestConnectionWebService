using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestConnectionWebServiceBO;
using TestConnectionWebServiceEntity;

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

            string paginas = new PaginaBO(url, usuario, senha).BuscarPagina(userAgent, contentType, body);

            Console.Write(paginas);

            Console.ReadKey();
        }        
    }
}
