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

                writer.WriteStartElement("Autenticacao_Header");
                writer.WriteString(arquivo.Autenticacao_Header.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("User_0");
                writer.WriteString(arquivo.User_0);
                writer.WriteEndElement();

                writer.WriteStartElement("Password_0");
                writer.WriteString(arquivo.Password_0);
                writer.WriteEndElement();

                writer.WriteStartElement("User_1");
                writer.WriteString(arquivo.User_1);
                writer.WriteEndElement();

                writer.WriteStartElement("Password_1");
                writer.WriteString(arquivo.Password_1);
                writer.WriteEndElement();

                writer.WriteStartElement("Content_Type");
                writer.WriteString(arquivo.Content_Type);
                writer.WriteEndElement();

                writer.WriteStartElement("User_Agent");
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
