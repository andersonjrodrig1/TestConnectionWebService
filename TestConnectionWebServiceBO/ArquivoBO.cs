using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestConnectionWebServiceDAO;
using TestConnectionWebServiceEntity;
using TestConnectionWebServiceUtil;

namespace TestConnectionWebServiceBO
{
    public class ArquivoBO
    {
        public string GravarArquivo(Arquivo arquivo)
        {
            try
            {
                DadosConfig dados = new DadosConfigBO().BuscarDadosConfiguracao();

                if (arquivo == null)
                {
                    return "Falha ao salvar os dados. Arquivo inconsistente.";
                }

                if (dados == null)
                {
                    return "Falha ao salvar os dados! Configuração inexistente.";
                }

                if (!Util.ExisteDiretorio(dados.Path_Arquivo_Registro))
                    Util.CriarDiretorio(dados.Path_Arquivo_Registro);

                if (!Util.ExisteArquivo(dados.Path_Arquivo_Registro, arquivo.Nome))
                    Util.CriarArquivo(dados.Path_Arquivo_Registro, arquivo.Nome);

                return new ArquivoDAO().SalvarDadosArquivo(arquivo, dados);
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public List<string> BuscarNomeArquivosGravados()
        {
            List<string> nomesArquivo = null;
            DadosConfig dados = new DadosConfigBO().BuscarDadosConfiguracao();

            if (dados == null)
                return nomesArquivo;

            if (Util.ExisteDiretorio(dados.Path_Arquivo_Registro) && Util.ExisteArquivoDiretorio(dados.Path_Arquivo_Registro))
            {
                nomesArquivo = new List<string>();
                FileInfo[] info = Util.GetArquivosGravados(dados.Path_Arquivo_Registro);

                foreach(var inf in info)
                {
                    string nomeArquivo = inf.Name.Replace(inf.Extension, "");
                    nomesArquivo.Add(nomeArquivo);
                }
            }

            return nomesArquivo;
        }

        public Arquivo BuscarArquivoPorNome(string nomeArquivo)
        {
            Arquivo arquivo = null;
            DadosConfig dados = new DadosConfigBO().BuscarDadosConfiguracao();

            if (string.IsNullOrEmpty(nomeArquivo) || dados == null)
                throw new Exception();

            nomeArquivo = string.Concat(nomeArquivo, ".xml");
            
            if(Util.ExisteArquivo(dados.Path_Arquivo_Registro, nomeArquivo))
            {
                arquivo = new Arquivo();
                string pathFile = string.Concat(dados.Path_Arquivo_Registro, nomeArquivo);
                arquivo = Util.GetDadosArquivo<Arquivo>(arquivo, pathFile);
            }

            return arquivo;
        }

        public Arquivo GerarArquivo(string nome, string url, string requisicao, bool semAutent, bool autenticacao, 
            bool basic, bool header, string keyA, string valueA, string keyB, string valueB, string content, string agent, string body)
        {
            Arquivo arquivo = new Arquivo();
            arquivo.Nome = nome;
            arquivo.Url_Conexao = url;
            arquivo.Tipo_Requisicao = requisicao;
            arquivo.Sem_Autenticacao = semAutent;
            arquivo.Com_Autenticacao = autenticacao;
            arquivo.Autenticacao_Basic = basic;
            arquivo.Autenticacao_Header = header;
            arquivo.User_0 = keyA;
            arquivo.Password_0 = valueA;
            arquivo.User_1 = keyB;
            arquivo.Password_1 = valueB;
            arquivo.Content_Type = content;
            arquivo.User_Agent = agent;
            arquivo.Body = body;

            return arquivo;
        }
    }
}
