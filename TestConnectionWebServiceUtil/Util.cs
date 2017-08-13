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

        public static T GetDadosArquivo<T>(T dados, string arquivo = null)
        {
            XmlDocument document = new XmlDocument();
            PropertyInfo[] propertyInfo = dados.GetType().GetProperties();

            if (string.IsNullOrEmpty(arquivo))
            {
                document.Load(arquivoXml);
            }
            else
            {
                document.Load(arquivo);
            }

            XmlNode xml = document.SelectSingleNode(document.DocumentElement.Name);

            foreach (var info in propertyInfo)
            {
                string valor = xml.SelectSingleNode(info.Name).InnerText;

                if (info.PropertyType == typeof(bool))
                {
                    info.SetValue(dados, Convert.ToBoolean(valor), null);
                }
                else if (info.PropertyType == typeof(int))
                {
                    info.SetValue(dados, Convert.ToInt32(valor), null);
                }
                else
                {
                    info.SetValue(dados, valor, null);
                }
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
                string arquivo = "";

                nomeArquivo = string.Concat(nomeArquivo, ".xml");
                arquivo = string.Concat(diretorioArquivo, nomeArquivo);

                if (!string.IsNullOrEmpty(arquivo))
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
            string arquivo = string.Concat(diretorioArquivo, nomeArquivo);

            if (!string.IsNullOrEmpty(arquivo))
            {
                if (!File.Exists(arquivo))
                    return false;
            }

            return true;
        }
    }
}
