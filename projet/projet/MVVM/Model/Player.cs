using AttackPlayers;

namespace Players
{
    class Player
    {
        public string Name { get; }

        public int Pv { get; private set; }
        
        public int Mana { get; private set; }

        public int Level { get; private set; }

        public List<AttackPlayer> Attack { get; } = new List<AttackPlayer>();

        public Player(string name, int pv, int mana, int level)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
            Level = level;
        }

        public bool IsAlivePlayer()
        {
            return Pv > 0;
        }
    }
}