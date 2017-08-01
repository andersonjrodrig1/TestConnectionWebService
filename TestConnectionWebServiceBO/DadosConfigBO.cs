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
        public DadosConfig BuscarDadosConfiguracao()
        {
            DadosConfig dados = new DadosConfig();
            dados = Util.GetDadosConfiguracao<DadosConfig>(dados);

            return dados;
        }
    }
}
