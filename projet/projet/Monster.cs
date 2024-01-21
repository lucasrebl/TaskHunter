namespace Monsters
{
    class Monster
    {
        public string Name { get; }

        public int Health { get; private set; }

        public int Mana { get; private set; }

        public string Category { get; }

        public Monster(string name, int health, int mana, string category)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Category = category;
        }

        public bool IsAliveMonster()
        {
            return Health > 0;
        }
    }
}