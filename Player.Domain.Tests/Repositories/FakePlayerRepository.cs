
using System;
using System.Collections.Generic;
using Player.Domain.Repositories;

namespace Player.Domain.Tests.Repositories
{
    public class FakePlayerRepository : IPlayerRepository
    {
        public void Create(Entities.Player player)
        {
            
        }

        public IEnumerable<Entities.Player> GetAllAssists(int assist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Player> GetAllGoals(int goals)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Player> GetByPlayers(string name, int goals, int assists)
        {
            throw new NotImplementedException();
        }

        public Entities.Player GetById(Guid Id, string name)
        {
            return new Entities.Player("ronaldo",20,20);
        }

        public void Update(Entities.Player player)
        {
           
        }
    }
}