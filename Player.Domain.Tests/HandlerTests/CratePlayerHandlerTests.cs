
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player.Domain.Command;
using Player.Domain.Commands;
using Player.Domain.Handlers;
using Player.Domain.Tests.Repositories;

namespace Player.Domain.Tests.HandlersTests
{
    [TestClass]
    
    public class CreatePlayerHandlerTests
    {
        private readonly CreatePlayerCommand _invalidCommand = new CreatePlayerCommand("", 1220,25007);
        private readonly CreatePlayerCommand _validCommand = new CreatePlayerCommand("Ronaldo",12,25);
        private readonly PlayerHandler _handler = new PlayerHandler(new FakePlayerRepository());
        

        public CreatePlayerHandlerTests()
        {
         
        }
        [TestMethod]
        public void Dado_um_comando_invalido_deve_interroper_a_execução()
        {
            
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Sucess, false);
        }
        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_um_player()
        {          
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Sucess, true);
        }
    }
}