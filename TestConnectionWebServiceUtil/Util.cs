using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionWebServiceUtil
{
    public class Util
    {
        public static T Deserializar<T>(string json)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            return result;
        }
    }
}
