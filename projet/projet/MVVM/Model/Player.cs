using AttackPlayers;
using Monsters;

namespace Players
{
    [Serializable]
    public class Player
    {
        private static Player _instance;
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
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player("joueur", 40000, 40000, 1);
                    _instance.Attack.Add(new AttackPlayer("Coup de pied", 10, 0));
                    _instance.Attack.Add(new AttackPlayer("Coup de poing", 10, 0));
                    _instance.Attack.Add(new AttackPlayer("FireBall", 25, 10));
                    _instance.Attack.Add(new AttackPlayer("Thunder", 30, 15));
                }
                return _instance;
            }
        }

        public bool IsAlivePlayer()
        {
            return Pv > 0;
        }

        public void CastAttack(AttackPlayer attackPlayer, Monster target)
        {
            Mana -= attackPlayer.ManaCost;
            target.ApplyDamage(attackPlayer.Damage);
        }

        public string GetStatusPlayer()
        {
            return $"{Name}: PV = {Pv}, Mana = {Mana}, Level = {Level}";
        }

        public void ApplyDamage(int damage)
        {
            Pv -= damage;
        }

        public void ApplyStealMana()
        {
            Mana -= 20;
        }
    }
}