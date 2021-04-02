using System;
using System.Collections.Generic;
using Player.Domain.Entities;

namespace Player.Domain.Repositories
{
    public interface IPlayerRepository
    {
        void Create(Player.Domain.Entities.Player player);

        void Update (Player.Domain.Entities.Player player);

        Player.Domain.Entities.Player GetById(Guid Id, string name);

        IEnumerable<Player.Domain.Entities.Player> GetAllGoals(int goals);
        IEnumerable<Player.Domain.Entities.Player> GetAllAssists(int assist);
        IEnumerable<Player.Domain.Entities.Player> GetByPlayers(string name, int goals, int assists);
    }
}    