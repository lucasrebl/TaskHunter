using AttackManaPlayers;
using AttackPlayers;

namespace Players
{
    class Player
    {
        public string Name { get; }
        
        public int Health { get; private set; }
        
        public int Mana { get; private set; }

        public int Level { get; private set; }


        public List<AttackManaPlayer> AttackManaPlayers { get; } = new List<AttackManaPlayer>();
        public List<AttackPlayer> AttackPlayers { get; } = new List<AttackPlayer>();


        public Player(string name, int health, int mana, int level)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Level = level;
        }

        public bool IsAlivePlayer()
        {
            return Health > 0;
        }
    }
}