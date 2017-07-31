using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        public static void GetDadosConfiguracao<T>(ref T dados)
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
        }
    }
}
