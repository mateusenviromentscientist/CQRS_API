using System;
using System.Linq.Expressions;

namespace Player.Domain.Queries
{
    public static class PlayerQueries
    {   
        public static Expression<Func<Player.Domain.Entities.Player, bool>> GetAll(string name)
        {
            return x => x.Name == name;
        }
        public static Expression<Func<Player.Domain.Entities.Player, bool>> GetAllGoals(int goals)
        {
            return x => x.Goals == goals;
        }
        public static Expression<Func<Player.Domain.Entities.Player, bool>> GetAllAssists(int assists)
        {
            return x => x.Assists == assists;
        }
        public static Expression<Func<Player.Domain.Entities.Player, bool>> GetByPlayer(string name, int goals, int assists)
        {
            return x => 
            x.Name == name &&
            x.Goals == goals &&
            x.Assists == assists;
        }
    }
}