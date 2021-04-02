using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Player.Domain.Infra.Contexts;
using Player.Domain.Queries;
using Player.Domain.Repositories;

namespace Player.Domain.Infra.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Entities.Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public IEnumerable<Entities.Player> GetAllAssists(int assist) // asnotracking é utilizado para só por na tela algo
        {
            return _context.Players.AsNoTracking().Where(PlayerQueries.GetAllAssists(assist)).OrderBy(x => x.Name);
        }

        public IEnumerable<Entities.Player> GetAllGoals(int goals)
        {
            return _context.Players.AsNoTracking().Where(PlayerQueries.GetAllAssists(goals)).OrderBy(x => x.Name);
        }
        public IEnumerable<Entities.Player> GetByPlayers(string name, int goals, int assists)
        {
            return _context.Players.AsNoTracking().Where(PlayerQueries.GetByPlayer(name, goals, assists)).OrderBy(x => x.Name);
        }

        public Entities.Player GetById(Guid Id, string name)
        {
            return _context.Players.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Entities.Player player)
        {
            _context.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

    }
}