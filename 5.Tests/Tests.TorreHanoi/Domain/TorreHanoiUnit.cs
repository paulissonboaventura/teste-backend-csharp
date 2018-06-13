using System;
using Infrastructure.TorreHanoi.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.TorreHanoi.Domain
{
    [TestClass]
    public class TorreHanoiUnit
    {
        private const string CategoriaTeste = "Domain/TorreHanoi";

        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLogger.Setup(s => s.Logar(It.IsAny<string>(), It.IsAny<TipoLog>()));
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Construtor_Deve_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.IsNotNull(torre.Discos);
            Assert.IsNotNull(torre.PassoAPasso);
            Assert.IsNotNull(torre.Destino);
            Assert.IsNotNull(torre.Origem);
            Assert.IsNotNull(torre.Intermediario);
            Assert.AreEqual(torre.Origem.Tipo, global::Domain.TorreHanoi.TipoPino.Origem);
            Assert.AreEqual(torre.Destino.Tipo, global::Domain.TorreHanoi.TipoPino.Destino);
            Assert.AreEqual(torre.Intermediario.Tipo, global::Domain.TorreHanoi.TipoPino.Intermediario);
            Assert.AreEqual(torre.Intermediario.Discos.Count, 0);
            Assert.AreEqual(torre.Destino.Discos.Count, 0);
            Assert.AreEqual(torre.Origem.Discos.Count, 3);
            Assert.AreEqual(torre.Status, global::Domain.TorreHanoi.TipoStatus.Pendente);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Processar_Deverar_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.IsNotNull(torre.Discos);
            Assert.IsNotNull(torre.Destino);
            Assert.IsNotNull(torre.Origem);
            Assert.IsNotNull(torre.Intermediario);

            torre.Processar();

            Assert.AreEqual(torre.Destino.Discos.Count, 3);
            Assert.AreEqual(torre.Origem.Discos.Count, 0);
            Assert.AreEqual(torre.Intermediario.Discos.Count, 0);

            Assert.AreEqual(((global::Domain.TorreHanoi.Disco)torre.Destino.Discos.ToArray().GetValue(0)).Id, 1);
            Assert.AreEqual(((global::Domain.TorreHanoi.Disco)torre.Destino.Discos.ToArray().GetValue(1)).Id, 2);
            Assert.AreEqual(((global::Domain.TorreHanoi.Disco)torre.Destino.Discos.ToArray().GetValue(2)).Id, 3);
        }
    }
}
