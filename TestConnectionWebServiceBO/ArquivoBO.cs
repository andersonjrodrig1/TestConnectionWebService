using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceBO
{
    public class ArquivoBO
    {
        public string GravarArquivo(Arquivo arquivo)
        {
            string mensagem = "";
            DadosConfig dados = new DadosConfig();

            dados = new DadosConfigBO().BuscarDadosConfiguracao();

            if(dados == null)
            {
                mensagem = "Falha ao salvar os dados!";
                return mensagem;
            }

            if (!ExisteArquivo(dados.Path_Arquivo_Registro, dados.Arquivo_Registro))
                CriarArquivo(dados.Path_Arquivo_Registro, dados.Arquivo_Registro);

            return SalvarDadosArquivo(arquivo, dados);
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
            arquivo.Dados_Autenticacao = new Dictionary<string, string>();

            if (arquivo.Com_Autenticacao || arquivo.Autenticacao_Basic)
                arquivo.Dados_Autenticacao.Add(keyA, valueA);
            else if(arquivo.Autenticacao_Header)
            {
                arquivo.Dados_Autenticacao.Add(keyA, valueA);
                arquivo.Dados_Autenticacao.Add(keyB, valueB);
            }

            arquivo.Content = content;
            arquivo.Agent = agent;
            arquivo.Body = body;

            return arquivo;
        }

        private string SalvarDadosArquivo(Arquivo arquivo, DadosConfig dados)
        {
            string retorno = "";
            string arquivoDados = string.Format("{0}\\{1}", dados.Path_Arquivo_Registro, dados.Arquivo_Registro);

            try
            {
                XmlTextWriter writer = new XmlTextWriter(arquivoDados, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("WebServices");

                writer.WriteStartElement("Nome");
                writer.WriteString(arquivo.Nome);
                writer.WriteEndElement();

                writer.WriteStartElement("UrlWebService");
                writer.WriteString(arquivo.Url_Conexao);
                writer.WriteEndElement();

                writer.WriteStartElement("Requisicao");
                writer.WriteString(arquivo.Tipo_Requisicao);
                writer.WriteEndElement();

                //TODO: Terminar preenchimento do arquivo para escrita

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Close();

                retorno = "Salvo com sucesso!";
            }
            catch (FileLoadException ex)
            {
                retorno = ex.ToString();
            }

            return retorno;
        }

        private void CriarArquivo(string diretorioArquivo, string nomeArquivo)
        {
            string arquivo = string.Format("{0}\\{1}", diretorioArquivo, nomeArquivo);

            File.Create(arquivo).Dispose();
        }

        private bool ExisteArquivo(string diretorioArquivo, string nomeArquivo)
        {
            bool existe = false;
            string arquivo = string.Format("{0}\\{1}", diretorioArquivo, nomeArquivo);

            if (File.Exists(arquivo))
                existe = true;

            return existe;
        }
    }
}
