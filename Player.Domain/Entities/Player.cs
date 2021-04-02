using System;

namespace Player.Domain.Entities
{
    public class Player : Entity
    {
        public Player(string name, int assists, int goals)
        {
            Name = name;
            Assists = assists;
            Goals = goals;
        }

        public string Name { get; private set; }
        public int Assists {get ; private set;}
        public int Goals { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}