using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player.Domain.Commands;

namespace Player.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Dado_um_comando_inválido()
        {
            var command = new CreatePlayerCommand("", 1220,25007);
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }
        
        [TestMethod]
        public void Dado_um_comando_válido()
        {
            var command = new CreatePlayerCommand("Ronaldo", 10,25);
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}
