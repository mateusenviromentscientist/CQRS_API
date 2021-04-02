using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player.Domain.Queries;

namespace Player.Domain.Tests.QueriesTests
{
    [TestClass]
    public class PlayerQueriesTests
    {
        private System.Collections.Generic.List<Player.Domain.Entities.Player> _players;
        public PlayerQueriesTests()
        {
            _players = new System.Collections.Generic.List<Entities.Player>();
            _players.Add(new Entities.Player("caça rato", 20, 30));
            _players.Add(new Entities.Player("Ronaldo", 20, 30));
            _players.Add(new Entities.Player("Ronaldo", 20, 30));
        }
        [TestMethod]
        public void Dada_a_consulta_Deve_retornar_nome_apenas_do_caça_rato()
        {
            var result = _players.AsQueryable().Where(PlayerQueries.GetAll("Ronaldo"));
            Assert.AreEqual(2,result.Count());
        }
    }
}