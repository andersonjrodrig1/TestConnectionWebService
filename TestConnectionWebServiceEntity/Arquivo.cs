using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionWebServiceEntity
{
    public class Arquivo
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public string Url_Conexao { get; set; }
        public string Tipo_Requisicao { get; set; }
        public bool Sem_Autenticacao { get; set; }
        public bool Com_Autenticacao { get; set; }
        public bool Autenticacao_Basic { get; set; }
        public bool Autenticacao_Header { get; set; }
        public Dictionary<string,string> Dados_Autenticacao { get; set; }
        public string Content { get; set; }
        public string Agent { get; set; }
        public string Body { get; set; }
    }
}
