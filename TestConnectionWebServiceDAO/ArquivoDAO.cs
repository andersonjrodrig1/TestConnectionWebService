using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceDAO
{
    public class ArquivoDAO
    {
        public string SalvarDadosArquivo(Arquivo arquivo, DadosConfig dados)
        {
            string retorno = "";
            string arquivoDados = string.Format("{0}\\{1}.xml", dados.Path_Arquivo_Registro, arquivo.Nome);

            try
            {
                XmlDocument xml = new XmlDocument();
                XmlTextWriter writer = new XmlTextWriter(arquivoDados, System.Text.Encoding.UTF8);

                writer.WriteStartDocument(false);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;                
                writer.WriteStartElement("WebServices");

                writer.WriteStartElement("Codigo");
                writer.WriteString(arquivo.Codigo.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Nome");
                writer.WriteString(arquivo.Nome);
                writer.WriteEndElement();

                writer.WriteStartElement("Url_Conexao");
                writer.WriteString(arquivo.Url_Conexao);
                writer.WriteEndElement();

                writer.WriteStartElement("Tipo_Requisicao");
                writer.WriteString(arquivo.Tipo_Requisicao);
                writer.WriteEndElement();

                writer.WriteStartElement("Sem_Autenticacao");
                writer.WriteString(arquivo.Sem_Autenticacao.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Com_Autenticacao");
                writer.WriteString(arquivo.Com_Autenticacao.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Autenticacao_Basic");
                writer.WriteString(arquivo.Autenticacao_Basic.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Autenticao_Header");
                writer.WriteString(arquivo.Autenticacao_Header.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Dados_Autenticacao");

                if(arquivo.Dados_Autenticacao != null && arquivo.Dados_Autenticacao.Count > 0)
                {
                    foreach (var dado in arquivo.Dados_Autenticacao) {
                        writer.WriteStartElement("Usuario");
                        writer.WriteString(dado.Key);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Senha");
                        writer.WriteString(dado.Value);
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();

                writer.WriteStartElement("Content_Type");
                writer.WriteString(arquivo.Content_Type);
                writer.WriteEndElement();

                writer.WriteStartElement("User_Agente");
                writer.WriteString(arquivo.User_Agent);
                writer.WriteEndElement();

                writer.WriteStartElement("Body");
                writer.WriteString(arquivo.Body);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                xml.Save(writer);                

                retorno = "Salvo com sucesso!";
            }
            catch (Exception ex)
            {
                retorno = ex.ToString();
            }

            return retorno;
        }
    }
}
