using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionWebServiceEntity
{
    public class Arquivo
    {
        public string Nome { get; set; }
        public string Url_Conexao { get; set; }
        public string Tipo_Requisicao { get; set; }
        public bool Sem_Autenticacao { get; set; }
        public bool Com_Autenticacao { get; set; }
        public bool Autenticacao_Basic { get; set; }
        public bool Autenticacao_Header { get; set; }
        public string User_0 { get; set; }
        public string Password_0 { get; set; }
        public string User_1 { get; set; }
        public string Password_1 { get; set; }
        public string Content_Type { get; set; }
        public string User_Agent { get; set; }
        public string Body { get; set; }
    }
}
