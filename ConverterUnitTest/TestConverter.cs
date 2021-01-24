using System.Transactions;
using ConvertingValuta;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConverterUnitTest
{
    [TestClass]
    public class TestConverter
    {
        private static double Delta = 0.001;
        [TestMethod]
        public void KonverterTilDanske()
        {

            //arrange
            double svenskeKroner = 10;

            //act
            double result = ValutaConverter.TilDanske(svenskeKroner);

            //assert
            Assert.AreEqual(7.041, result, Delta);
        }

        [TestMethod]
        public void KonverterTilSvenske()
        {
            //arrange
            double danskeKroner = 10;

            //act
            double result = ValutaConverter.TilSvenske(danskeKroner);

            //assert
            Assert.AreEqual(14.202, result, Delta);
        }
    }
}
