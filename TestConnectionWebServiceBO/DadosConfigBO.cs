using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestConnectionWebServiceEntity;
using TestConnectionWebServiceUtil;

namespace TestConnectionWebServiceBO
{
    public class DadosConfigBO
    {
        private static string arquivoXml = @"D:\Visual Studio 2017\TestConnectionWebService\TestConnectionWebServiceWeb\Models\Config\DadosConfig.config";

        public static DadosConfig BuscarDadosConfiguracao()
        {
            DadosConfig dados = new DadosConfig();
            Util.GetDadosConfiguracao<DadosConfig>(ref dados);

            return dados;
        }
    }
}
