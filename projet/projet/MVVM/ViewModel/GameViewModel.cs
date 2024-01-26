using AttackMonsters;
using AttackPlayers;
using Monsters;
using Players;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace projet.MVVM.ViewModel
{
    class GameViewModel
    {
        private string _gameStatus;
        private string _monsterLife;
        private string _monsterName;
        private string _monsterMana;
        private string _playerLife;
        private string _playerMana;
        private string _enemyImgSource;
        public string GameStatus
        {
            get { return _gameStatus; }
            set
            {
                if (_gameStatus != value)
                {
                    _gameStatus = value;
                    OnPropertyChanged(nameof(GameStatus));
                }
            }
        }

        public string EnemyImgSource
        {
            get { return _enemyImgSource; }
            set
            {
                if (_enemyImgSource != value)
                {
                    _enemyImgSource = value;
                    OnPropertyChanged(nameof(EnemyImgSource));
                }
            }
        }

        public string MonsterLife
        {
            get { return _monsterLife; }
            set
            {
                if (_monsterLife != value)
                {
                    _monsterLife = value;
                    OnPropertyChanged(nameof(MonsterLife));
                }
            }
        }

        public string MonsterName
        {
            get { return _monsterName; }
            set
            {
                if (_monsterName != value)
                {
                    _monsterName = value;
                    OnPropertyChanged(nameof(MonsterName));
                }
            }
        }
        public string MonsterMana
        {
            get { return _monsterMana; }
            set
            {
                if (_monsterMana != value)
                {
                    _monsterMana = value;
                    OnPropertyChanged(nameof(MonsterMana));
                }
            }
        }

        public string PlayerLife
        {
            get { return _playerLife; }
            set
            {
                if (_playerLife != value)
                {
                    _playerLife = value;
                    OnPropertyChanged(nameof(PlayerLife));
                }
            }
        }

        public string PlayerMana
        {
            get { return _playerMana; }
            set
            {
                if (_playerMana != value)
                {
                    _playerMana = value;
                    OnPropertyChanged(nameof(PlayerMana));
                }
            }
        }

        public ICommand PunchCommand { get; set; }
        public ICommand KickCommand { get; set; }
        public ICommand FireballCommand { get; set; }
        public ICommand ThunderCommand { get; set; }
        public ICommand InventoryCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        static Random rand = new Random();

        public void InitializeGame(Player player)
        {
            Game(player);
        }

        public void Game(Player player)
        {
            int NbWawes = 0;
            List<Monster> monsters = InitMonster();
            Monster monster = null;

            while (player.IsAlivePlayer())
            {
                if (monster == null || !monster.IsAliveMonster())
                {
                    if (monster != null)
                    {
                        GameStatus = $"Vous avez vaincu {monster.Name}";
                    }

                    if (player.IsAlivePlayer())
                    {
                        NbWawes++;
                        GameStatus = $"Vague actuelle: {NbWawes}";
                        monster = GetRandomMonster(monsters, NbWawes);
                        monster.ResetStats();
                        GameStatus = $"Un nouveau monstre apparaît : {monster.Name} ! Pour certaines raisons, il n'a pas pu vous attaquer...";
                        MonsterName = $"{monster.Name}";
                        MonsterMana = $"{monster.Mana}";
                        MonsterLife = $"{monster.Health}";
                        PlayerMana = $"{player.Mana}";
                        PlayerLife = $"{player.Pv}";
                        EnemyImgSource = $"{monster.Img}";
                    }
                }
                //GameStatus = $"Etat du joueur: {player.GetStatusPlayer()}";
                //GameStatus = $"Etat du Monstre: {monster.GetStatusMonster()}";

                Action();
                string userAction = Console.ReadLine();
                Console.WriteLine();

                userAction = "1";

                switch (userAction.ToLower())
                {
                    case "1":
                        if (player.Attack.Any(attack => attack.Name == "Coup de poing"))
                        {
                            AttackPlayer punchAttack = player.Attack.First(attack => attack.Name == "Coup de poing");
                            if (player.Mana > punchAttack.ManaCost)
                            {
                                player.CastAttack(punchAttack, monster);
                                Console.WriteLine($"Vous avez lancé {punchAttack.Name} et infligé {punchAttack.Damage} points de dégâts au {monster.Name}!");
                            }
                            else
                            {
                                Console.WriteLine("pas assez de mana");
                            }
                        }
                        if (monster.IsAliveMonster())
                        {
                            if (monster.Category == "common")
                            {
                                monster.PerformAttackCommon(player);
                            }
                            else if (monster.Category == "rare")
                            {
                                monster.PerformAttackRare(player);
                            }
                            else if (monster.Category == "epic")
                            {
                                monster.PerformAttackEpic(player);
                            }
                            else if (monster.Category == "Legendary")
                            {
                                monster.PerformAttackLegendary(player);
                            }
                            else if (monster.Category == "Boss")
                            {
                                monster.PerformAttackBoss(player);
                            }
                        }
                        break;
                    case "2":
                        if (player.Attack.Any(attack => attack.Name == "Coup de pied"))
                        {
                            AttackPlayer footAttack = player.Attack.First(attack => attack.Name == "Coup de pied");
                            if (player.Mana > footAttack.ManaCost)
                            {
                                player.CastAttack(footAttack, monster);
                                Console.WriteLine($"Vous avez lancé {footAttack.Name} et infligé {footAttack.Damage} points de dégâts au {monster.Name}!");
                            }
                            else
                            {
                                Console.WriteLine("pas assez de mana");
                            }
                        }
                        if (monster.IsAliveMonster())
                        {
                            if (monster.Category == "common")
                            {
                                monster.PerformAttackCommon(player);
                            }
                            else if (monster.Category == "rare")
                            {
                                monster.PerformAttackRare(player);
                            }
                            else if (monster.Category == "epic")
                            {
                                monster.PerformAttackEpic(player);
                            }
                            else if (monster.Category == "Legendary")
                            {
                                monster.PerformAttackLegendary(player);
                            }
                            else if (monster.Category == "Boss")
                            {
                                monster.PerformAttackBoss(player);
                            }
                        }
                        break;
                    case "3":
                        if (player.Attack.Any(attack => attack.Name == "FireBall"))
                        {
                            AttackPlayer fireballAttack = player.Attack.First(attack => attack.Name == "FireBall");
                            if (player.Mana > fireballAttack.ManaCost)
                            {
                                player.CastAttack(fireballAttack, monster);
                                Console.WriteLine($"Vous avez lancé {fireballAttack.Name} et infligé {fireballAttack.Damage} points de dégâts au {monster.Name}!");
                            }
                            else
                            {
                                Console.WriteLine("pas assez de mana");
                            }
                        }
                        if (monster.IsAliveMonster())
                        {
                            if (monster.Category == "common")
                            {
                                monster.PerformAttackCommon(player);
                            }
                            else if (monster.Category == "rare")
                            {
                                monster.PerformAttackRare(player);
                            }
                            else if (monster.Category == "epic")
                            {
                                monster.PerformAttackEpic(player);
                            }
                            else if (monster.Category == "Legendary")
                            {
                                monster.PerformAttackLegendary(player);
                            }
                            else if (monster.Category == "Boss")
                            {
                                monster.PerformAttackBoss(player);
                            }
                        }
                        break;
                    case "4":
                        if (player.Attack.Any(attack => attack.Name == "Thunder"))
                        {
                            AttackPlayer thunderAttack = player.Attack.First(attack => attack.Name == "Thunder");
                            if (player.Mana > thunderAttack.ManaCost)
                            {
                                player.CastAttack(thunderAttack, monster);
                                Console.WriteLine($"Vous avez lancé {thunderAttack.Name} et infligé {thunderAttack.Damage} points de dégâts au {monster.Name}!");
                            }
                            else
                            {
                                Console.WriteLine("pas assez de mana");
                            }
                        }
                        if (monster.IsAliveMonster())
                        {
                            if (monster.Category == "common")
                            {
                                monster.PerformAttackCommon(player);
                            }
                            else if (monster.Category == "rare")
                            {
                                monster.PerformAttackRare(player);
                            }
                            else if (monster.Category == "epic")
                            {
                                monster.PerformAttackEpic(player);
                            }
                            else if (monster.Category == "Legendary")
                            {
                                monster.PerformAttackLegendary(player);
                            }
                            else if (monster.Category == "Boss")
                            {
                                monster.PerformAttackBoss(player);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("utilisé une attaque valid");
                        break;
                }
            }
            Console.WriteLine("Vous êtes mort");
        }

        public static void Action()
        {
            Console.WriteLine("Attack Possible");
            Console.WriteLine("1: Cout de poing");
            Console.WriteLine("2: Cout de pied");
            Console.WriteLine("3: Fireball");
            Console.WriteLine("4: Thunder");
        }

        public static List<Monster> InitMonster()
        {
            List<Monster> monsters = new List<Monster>
        {
            // monstres Common
            new Monster("Slime", 20, 15, "common", GetRandomAttacksCommon("common", 4), rand, "/Images/Monsters/slime.gif"),
            new Monster("Sprout", 25, 20, "common", GetRandomAttacksCommon("common", 4), rand, "/Images/Monsters/sprout.gif"),
            new Monster("Spoink", 35, 25, "common", GetRandomAttacksCommon("common", 4), rand, "/Images/Monsters/spoink.gif"),

            // Monstres rare
            new Monster("French Pampa", 45, 60, "rare", GetRandomAttacksRare("rare", 4), rand, "/Images/Monsters/frenchpampa.png"),
            new Monster("Hatsune Miku", 40, 25, "rare", GetRandomAttacksRare("rare", 4), rand, "/Images/Monsters/miku.gif"),
            new Monster("Sakamèche", 50, 50, "rare", GetRandomAttacksRare("rare", 4), rand, "/Images/Monsters/salameche.gif"),

            // Monstres epic
            new Monster("Golden Hand", 80, 40, "epic", GetRandomAttacksEpic("epic", 4), rand, "/Images/Monsters/goldenhand.png"),
            new Monster("Paimon", 80, 50, "epic", GetRandomAttacksEpic("epic", 4), rand, "/Images/Monsters/paimon.gif"),
            new Monster("Bukayo Saka", 80, 100, "epic", GetRandomAttacksEpic("epic", 4), rand, "/Images/Monsters/saka.png"),

            // Monstres Legendary
            new Monster("Marie", 100, 200, "Legendary", GetRandomAttacksLegendary("Legendary", 4), rand, "/Images/Monsters/isabelle.gif"),
            new Monster("Krokmou", 110, 70, "Legendary", GetRandomAttacksLegendary("Legendary", 4), rand, "/Images/Monsters/crocmou.gif"),
            new Monster("Mewtwo", 150, 150, "Legendary", GetRandomAttacksLegendary("Legendary", 4), rand, "/Images/Monsters/mewtwo.gif"),
            new Monster("Les Pieds", 120, 100, "Legendary", GetRandomAttacksLegendary("Legendary", 4), rand, "/Images/Monsters/pieds.gif"),

            // Monstres Boss
            new Monster("Rayquaza Shiny", 300, 150, "Boss", GetAttacksBoss("Boss"), rand, "/Images/Monsters/Rayquaza.gif"),
        };
            return monsters;
        }

        // list attacks Common
        static List<AttackMonster> GetRandomAttacksCommon(string categotyCommon, int numberOfAttacksCommon)
        {
            List<AttackMonster> allAttacksCommon = new List<AttackMonster>
        {
            new AttackMonster("Crachat", 1, 0, null, categotyCommon),
            new AttackMonster("Roulé-boulé", 2, 0, null, categotyCommon),
            new AttackMonster("Coup de pied", 3, 0, null, categotyCommon),
            new AttackMonster("Flamèche", 6, 5, null, categotyCommon),
            new AttackMonster("Attaque élémentaire", 7, 5, null, categotyCommon),
            new AttackMonster("Invocation", 15, 10, null, categotyCommon),
        };
            // mélange les attaques
            List<AttackMonster> shuffledAttacksCommon = allAttacksCommon.OrderBy(x => rand.Next()).ToList();
            // Sélectionnez les quatre premières attaques après le mélange
            List<AttackMonster> selectedAttacksCommon = shuffledAttacksCommon.Take(numberOfAttacksCommon).ToList();
            return selectedAttacksCommon;
        }

        // list attacks Rare
        static List<AttackMonster> GetRandomAttacksRare(string categoryRare, int numberOfAttacksRare)
        {
            List<AttackMonster> allAttacksRare = new List<AttackMonster>()
        {
            new AttackMonster("Saut", 10, 0, null, categoryRare),
            new AttackMonster("Boom Boom Bakudan", 20, 20, null, categoryRare),
            new AttackMonster("Bordel", 40, 0, "suicide", categoryRare),
            new AttackMonster("Grosse patate", 15, 5, null, categoryRare),
            new AttackMonster("Boule de neige", 20, 15, null, categoryRare),
            new AttackMonster("Vibraqua", 10, 5, null, categoryRare),
        };
            List<AttackMonster> shuffledAttacksRare = allAttacksRare.OrderBy(x => rand.Next()).ToList();
            List<AttackMonster> selectAttacksRare = shuffledAttacksRare.Take(numberOfAttacksRare).ToList();
            return selectAttacksRare;
        }

        // list attacks Epic
        static List<AttackMonster> GetRandomAttacksEpic(string categoryEpic, int numberOfAttacksEpic)
        {
            List<AttackMonster> allAttacksEpic = new List<AttackMonster>()
        {
            new AttackMonster("Tir canon", 65, 65, null, categoryEpic),
            new AttackMonster("Esquive", 0, 0, "esquive", categoryEpic),
            new AttackMonster("Lame d'air", 40, 20, null, categoryEpic),
            new AttackMonster("Insulte", 50, 30, null, categoryEpic),
            new AttackMonster("RN Attack'", 55, 30, null, categoryEpic),
            new AttackMonster("Nova Solaire", 75, 50, null, categoryEpic),
        };
            List<AttackMonster> shuffledAttacksEpic = allAttacksEpic.OrderBy(x => rand.Next()).ToList();
            List<AttackMonster> selectAttacksEpic = shuffledAttacksEpic.Take(numberOfAttacksEpic).ToList();
            return selectAttacksEpic;
        }

        // list attacks Legendary
        static List<AttackMonster> GetRandomAttacksLegendary(string categoryLegendary, int numberOfAttacksLegendary)
        {
            List<AttackMonster> allAttacksLegendary = new List<AttackMonster>()
        {
            new AttackMonster("Vol de mana", 0, 0, "vol", categoryLegendary),
            new AttackMonster("Danse endiablée", 55, 40, null, categoryLegendary),
            new AttackMonster("Reconquête", 0, 20, "heal", categoryLegendary),
            new AttackMonster("CurryAttack'", 35, 20, null, categoryLegendary),
            new AttackMonster("Double baffe", 70, 60, null, categoryLegendary),
            new AttackMonster("Frappe sismique", 90, 65, null, categoryLegendary),
        };
            List<AttackMonster> shuffledAttacksLegendary = allAttacksLegendary.OrderBy(x => rand.Next()).ToList();
            List<AttackMonster> selectAttacksLegendary = shuffledAttacksLegendary.Take(numberOfAttacksLegendary).ToList();
            return selectAttacksLegendary;
        }

        // list attacks Boss
        static List<AttackMonster> GetAttacksBoss(string categoryBoss)
        {
            List<AttackMonster> allAttacksBoss = new List<AttackMonster>()
        {
            new AttackMonster("Draco-Ascension", 120, 70, null, categoryBoss),
            new AttackMonster("ExpelledΑραβικά", 120, 200, null, categoryBoss),
            new AttackMonster("Evolution", 0, 0, "boost", categoryBoss),
            new AttackMonster("Colère", 80, 50, null, categoryBoss),
        };
            return allAttacksBoss;
        }

        public static Monster GetRandomMonster(List<Monster> monsters, int NbWawes)
        {
            if (NbWawes <= 10)
            {
                List<Monster> commonMonsters = monsters.Where(monster => monster.Category == "common").ToList();
                int randomIndexCommon = rand.Next(commonMonsters.Count);
                return commonMonsters[randomIndexCommon];
            }
            else if (NbWawes <= 20)
            {
                bool isRare = rand.Next(2) == 0;
                List<Monster> eligibleMonstersRareOrCommon = isRare
                    ? monsters.Where(monster => monster.Category == "rare").ToList()
                    : monsters.Where(monster => monster.Category == "common").ToList();

                int randomIndexRareOrCommon = rand.Next(eligibleMonstersRareOrCommon.Count);
                return eligibleMonstersRareOrCommon[randomIndexRareOrCommon];
            }
            else if (NbWawes <= 30)
            {
                List<Monster> rareMonsters = monsters.Where(monster => monster.Category == "rare").ToList();
                int randomIndexRare = rand.Next(rareMonsters.Count);
                return rareMonsters[randomIndexRare];
            }
            else if (NbWawes <= 40)
            {
                bool isEpic = rand.Next(2) == 0;
                List<Monster> eligibleMonsterEpicOrRare = isEpic
                    ? monsters.Where(monster => monster.Category == "epic").ToList()
                    : monsters.Where(monster => monster.Category == "rare").ToList();

                int randomIndexEpicOrRare = rand.Next(eligibleMonsterEpicOrRare.Count);
                return eligibleMonsterEpicOrRare[randomIndexEpicOrRare];
            }
            else if (NbWawes <= 50)
            {
                List<Monster> epicMonsters = monsters.Where(monster => monster.Category == "epic").ToList();
                int randomIndexEpic = rand.Next(epicMonsters.Count);
                return epicMonsters[randomIndexEpic];
            }
            else if (NbWawes <= 60)
            {
                bool isLegendary = rand.Next(2) == 0;
                List<Monster> eligibleMonstersLengendaryOrEpic = isLegendary
                    ? monsters.Where(monster => monster.Category == "Legendary").ToList()
                    : monsters.Where(monster => monster.Category == "epic").ToList();

                int randomIndexLEgendaryOrEpic = rand.Next(eligibleMonstersLengendaryOrEpic.Count);
                return eligibleMonstersLengendaryOrEpic[randomIndexLEgendaryOrEpic];
            }
            else if (NbWawes <= 70)
            {
                List<Monster> legendaryMonsters = monsters.Where(monster => monster.Category == "Legendary").ToList();
                int randomIndexLegendary = rand.Next(legendaryMonsters.Count);
                return legendaryMonsters[randomIndexLegendary];
            }
            else if (NbWawes <= 90)
            {
                if (rand.Next(5) == 0)
                {
                    List<Monster> bossMonsters = monsters.Where(monster => monster.Category == "Boss").ToList();
                    int randomIndexBoss = rand.Next(bossMonsters.Count);
                    return bossMonsters[randomIndexBoss];
                }
                else
                {
                    List<Monster> legendaryMonsters = monsters.Where(monster => monster.Category == "Legendary").ToList();
                    int randomIndexLegendary = rand.Next(legendaryMonsters.Count);
                    return legendaryMonsters[randomIndexLegendary];
                }
            }
            else if (NbWawes > 90)
            {
                List<Monster> bossMonsters = monsters.Where(monster => monster.Category == "Boss").ToList();
                int randomIndexBoss = rand.Next(bossMonsters.Count);
                return bossMonsters[randomIndexBoss];
            }
            int randomIndex = rand.Next(monsters.Count);
            return monsters[randomIndex];
        }
    }
}
