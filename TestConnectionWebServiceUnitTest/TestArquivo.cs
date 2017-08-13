using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConnectionWebServiceBO;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceUnitTest
{
    [TestClass]
    public class TestArquivo
    {
        [TestMethod]
        public void TestarArquivoExistente()
        {
            //Given
            ArquivoBO arquivoBO = new ArquivoBO();
            Arquivo arquivo = new Arquivo();
            string nomeArquivo = "Horario GDS";

            //When
            arquivo = arquivoBO.BuscarArquivoPorNome(nomeArquivo);

            //Then
            Assert.AreEqual(nomeArquivo, arquivo.Nome);
        }
    }
}
