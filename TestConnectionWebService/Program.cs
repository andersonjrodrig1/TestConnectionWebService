﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestConnectionWebServiceBO;
using TestConnectionWebServiceEntity;
using TestConnectionWebServiceUtil;

namespace TestConnectionWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            LerArquivoXML();
        }

        private static void ConsumirWebService()
        {
            string url = "http://jsonplaceholder.typicode.com/posts";
            string contentType = "application/json";
            string userAgent = "RequisicaoWebDemo";
            string body = "";
            string usuario = "";
            string senha = "";
            string strPaginas = "";

            try
            {
                strPaginas = new PaginaBO(url, usuario, senha).BuscarPagina(userAgent, contentType, body);
                Pagina[] paginas = Util.Deserializar<Pagina[]>(strPaginas);

                strPaginas = "";

                foreach (var pag in paginas)
                {
                    strPaginas += "----------------------------------------------------\n";
                    strPaginas += pag.id + "\n";
                    strPaginas += pag.userId + "\n";
                    strPaginas += pag.title + "\n";
                    strPaginas += pag.body + "\n";
                }
            }
            catch (Exception ex)
            {
                strPaginas = ex.ToString();
            }

            Console.Write(strPaginas);
            Console.ReadKey();
        }

        private static void LerArquivoXML()
        {
            DadosConfig dados = new DadosConfig();
            dados = Util.GetDadosArquivo<DadosConfig>(dados);

            Console.Write(dados.Path_Arquivo_Dados + "\n");
            Console.Write(dados.Arquivo_Dados + "\n");
            Console.Write(dados.Path_Arquivo_Registro + "\n");
            Console.ReadKey();
        }
    }
}
