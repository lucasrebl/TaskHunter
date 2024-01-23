using AttackMonstersBoss;

namespace MonstersBoss
{
    class MonsterBoss
    {
        public string Name { get; }

        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public List<AttackMonsterBoss> Attack2 { get; } = new List<AttackMonsterBoss>();

        public MonsterBoss(string name, int pv, int mana)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
        }

        public bool IsAliveBoss()
        {
            return Pv > 0;
        }
    }
}