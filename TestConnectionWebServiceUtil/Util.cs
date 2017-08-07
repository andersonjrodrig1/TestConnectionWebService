using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestConnectionWebServiceUtil
{
    public class Util
    {
        private static string arquivoXml = @"D:\Visual Studio 2017\TestConnectionWebService\TestConnectionWebServiceWeb\Models\Config\DadosConfig.config";

        public static T Deserializar<T>(string json)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        public static T GetDadosConfiguracao<T>(T dados)
        {
            XmlDocument document = new XmlDocument();
            PropertyInfo[] propertyInfo = dados.GetType().GetProperties();

            document.Load(arquivoXml);
            XmlNode xml = document.SelectSingleNode(document.DocumentElement.Name);

            foreach (var info in propertyInfo)
            {
                string valor = xml.SelectSingleNode(info.Name).InnerText;
                info.SetValue(dados, valor, null);
            }

            return dados;
        }

        public static FileInfo[] GetArquivosGravados(string diretorioArquivo)
        {
            DirectoryInfo diretorio = new DirectoryInfo(diretorioArquivo);
            FileInfo[] file = diretorio.GetFiles();

            return file;
        }

        public static void CriarDiretorio(string diretorioArquivo)
        {
            if (!string.IsNullOrEmpty(diretorioArquivo))
            {
                if (!ExisteDiretorio(diretorioArquivo))
                    Directory.CreateDirectory(diretorioArquivo);
            }
        }

        public static void CriarArquivo(string diretorioArquivo, string nomeArquivo)
        {
            if (!string.IsNullOrEmpty(diretorioArquivo) && !string.IsNullOrEmpty(nomeArquivo))
            {
                string arquivo = string.Format("{0}\\{1}.xml", diretorioArquivo, nomeArquivo);

                if (!string.IsNullOrEmpty(arquivo) && arquivo != ".xml")
                {
                    File.Create(arquivo).Dispose();
                }
            }
        }

        public static bool ExisteArquivoDiretorio(string diretorioArquivo)
        {
            if (ExisteDiretorio(diretorioArquivo))
            {
                FileInfo[] file = GetArquivosGravados(diretorioArquivo);

                if (file != null && file.Count() > 0)
                    return true;
            }

            return false;
        }

        public static bool ExisteDiretorio(string diretorioArquivo)
        {
            if (!Directory.Exists(diretorioArquivo))
                return false;

            return true;
        }

        public static bool ExisteArquivo(string diretorioArquivo, string nomeArquivo)
        {
            string arquivo = string.Format("{0}\\{1}.xml", diretorioArquivo, nomeArquivo);

            if (!string.IsNullOrEmpty(arquivo) && arquivo != ".xml")
            {
                if (!File.Exists(arquivo))
                    return false;
            }

            return true;
        }
    }
}
