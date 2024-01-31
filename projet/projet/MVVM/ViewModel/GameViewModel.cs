using AttackMonsters;
using AttackPlayers;
using Monsters;
using Players;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using projet.MVVM.Model;
using Inventorys;
using projet.Core;
using Inventorys;
using System.Xml.Linq;


namespace projet.MVVM.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        private string _gameStatus;
        private string _monsterLife;
        private string _monsterName;
        private string _monsterMana;
        private string _playerLife;
        private string _playerMana;
        private string _enemyImgSource;
        private Player player;

        public Player Player
        {
            get { return player; }
            set
            {
                if (player != value)
                {
                    if (player != null)
                    {
                        player.PropertyChanged -= Player_PropertyChanged;
                    }

                    player = value;

                    if (player != null)
                    {
                        player.PropertyChanged += Player_PropertyChanged;
                    }

                    OnPropertyChanged(nameof(Player));
                }
            }
        }

        private Player _actualPlayer;
        public ICommand Attack1Command { get; private set; }
        public ICommand Attack2Command { get; private set; }
        public ICommand Attack3Command { get; private set; }
        public ICommand Attack4Command { get; private set; }
        public ICommand ParchmentPvCommand { get; private set; }
        public ICommand ParchmentManaCommand { get; private set; }
        public ICommand PotionPvCommand { get; private set; }
        public ICommand PotionManaCommand { get; private set; }


        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

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

        private string parchmentPv;
        public string ParchmentPv
        {
            get { return parchmentPv; }
            set
            {
                if (parchmentPv != value)
                {
                    parchmentPv = value;
                    OnPropertyChanged(nameof(ParchmentPv));
                }
            }
        }

        private string parchmentMana;
        public string ParchmentMana
        {
            get { return parchmentMana; }
            set
            {
                if (parchmentMana != value)
                {
                    parchmentMana = value;
                    OnPropertyChanged(nameof(ParchmentMana));
                }
            }
        }

        private string potionPv;
        public string PotionPv
        {
            get { return potionPv; }
            set
            {
                if (potionPv != value)
                {
                    potionPv = value;
                    OnPropertyChanged(nameof(PotionPv));
                }
            }
        }

        private string potionMana;
        public string PotionMana
        {
            get { return potionMana; }
            set
            {
                if (potionMana != value)
                {
                    potionMana = value;
                    OnPropertyChanged(nameof(PotionMana));
                }
            }
        }

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        public Player ActualPlayer
        {
            get { return _actualPlayer; }
            set
            {
                if (_actualPlayer != value)
                {
                    _actualPlayer = value;
                    OnPropertyChanged(nameof(ActualPlayer));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static Random rand = new Random();
        Monster monster = null;
        List<Monster> monsters = InitMonster();
        int NbWawes = 0;

        public void InitializeGame(Player player)
        {
            Attack1Command = new RelayCommand(Attack1Clicked);
            Attack2Command = new RelayCommand(Attack2Clicked);
            Attack3Command = new RelayCommand(Attack3Clicked);
            Attack4Command = new RelayCommand(Attack4Clicked);
            ParchmentPvCommand = new RelayCommand(UseParchmentPv);
            ParchmentManaCommand = new RelayCommand(UseParchmentMana);
            PotionManaCommand = new RelayCommand(UsePotionMana);
            PotionPvCommand = new RelayCommand(UsePotionPv);
            SaveCommand = new RelayCommand(SaveGameCommand);
            LoadCommand = new RelayCommand(LoadGameCommand);
            ActualPlayer = player;

            monster = GetRandomMonster(monsters, NbWawes);
            monster.ResetStats();
            GameStatus += $"\nUn nouveau monstre apparaît : {monster.Name} ! Pour certaines raisons, il n'a pas pu vous attaquer...";
            MonsterName = $"{monster.Name}";
            MonsterMana = $"{monster.Mana}";
            MonsterLife = $"{monster.Health}";
            PlayerMana = $"{ActualPlayer.Mana}";
            PlayerLife = $"{ActualPlayer.Pv}";
            EnemyImgSource = $"{monster.Img}";
            ParchmentPv = $"{ActualPlayer.Inventory.ParchmentPv}";
            ParchmentMana = $"{ActualPlayer.Inventory.ParchmentMana}";
            PotionPv = $"{ActualPlayer.Inventory.PotionPv}";
            PotionMana = $"{ActualPlayer.Inventory.PotionMana}";
        }

        public void Death()
        {
            GameStatus = "Vous êtes mort, vos stats et le nombre vagues seront réinitialisés.";
            MonsterName = $"{monster.Name}";
            MonsterMana = $"{monster.Mana}";
            MonsterLife = $"{monster.Health}";
            PlayerMana = $"{ActualPlayer.Mana}";
            PlayerLife = "MORT";
            ActualPlayer.Reset();
            NbWawes = 0;
            ActualPlayer.Wins = 0;
            InitializeGame(ActualPlayer);
        }

        private void Attack1Clicked(object parameter)
        {
            GameStatus = "Attaque 1";

            if (ActualPlayer.IsAlivePlayer())
            {
                if (ActualPlayer.Attack.Any(attack => attack.Name == "Coup de poing"))
                {
                    AttackPlayer punchAttack = ActualPlayer.Attack.First(attack => attack.Name == "Coup de poing");
                    if (ActualPlayer.Mana > punchAttack.ManaCost)
                    {
                        ActualPlayer.CastAttack(punchAttack, monster);
                        GameStatus = $"Vous avez lancé {punchAttack.Name} et infligé {punchAttack.Damage} points de dégâts au {monster.Name}!";
                        UpdateStats();
                    }
                    else
                    {
                        GameStatus = "Vous n'avez pas assez de mana !";
                    }
                }
                if (monster.IsAliveMonster())
                {
                    if (monster.Category == "common")
                    {
                        string monsterAttackResult = monster.PerformAttackCommon(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "rare")
                    {
                        string monsterAttackResult = monster.PerformAttackRare(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "epic")
                    {
                        string monsterAttackResult = monster.PerformAttackEpic(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Legendary")
                    {
                        string monsterAttackResult = monster.PerformAttackLegendary(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Boss")
                    {
                        string monsterAttackResult = monster.PerformAttackBoss(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    UpdateStats();
                }

                if (monster == null || !monster.IsAliveMonster())
                {
                    if (monster != null)
                    {
                        GameStatus = $"Vous avez vaincu {monster.Name}";
                        monster.UpdatePlayerXP(ActualPlayer);
                        ActualPlayer.AddToPokedex(monster);
                    }
                    if (ActualPlayer.IsAlivePlayer())
                    {
                        NbWawes++;
                        GameStatus += $"\n Vague actuelle: {NbWawes}";
                        monster = GetRandomMonster(monsters, NbWawes);
                        monster.ResetStats();
                        ActualPlayer.ResetStatsPlayer();
                        GameStatus += $"\n Un nouveau monstre apparaît : {monster.Name} ! Pour certaines raisons, il n'a pas pu vous attaquer...";
                        UpdateStats();
                    }
                }
            }
            else
            {
                Death();
            }

        }

        private void Attack2Clicked(object parameter)
        {
            GameStatus = "Attaque 2";

            if (ActualPlayer.IsAlivePlayer())
            {

                if (ActualPlayer.Attack.Any(attack => attack.Name == "Coup de pied"))
                {
                    AttackPlayer footAttack = ActualPlayer.Attack.First(attack => attack.Name == "Coup de pied");
                    if (ActualPlayer.Mana > footAttack.ManaCost)
                    {
                        ActualPlayer.CastAttack(footAttack, monster);
                        GameStatus = $"Vous avez lancé {footAttack.Name} et infligé {footAttack.Damage} points de dégâts au {monster.Name}!";
                    }
                    else
                    {
                        GameStatus = "Vous n'avez pas assez de mana";
                    }
                }
                if (monster.IsAliveMonster())
                {
                    if (monster.Category == "common")
                    {
                        string monsterAttackResult = monster.PerformAttackCommon(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "rare")
                    {
                        string monsterAttackResult = monster.PerformAttackRare(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "epic")
                    {
                        string monsterAttackResult = monster.PerformAttackEpic(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Legendary")
                    {
                        string monsterAttackResult = monster.PerformAttackLegendary(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Boss")
                    {
                        string monsterAttackResult = monster.PerformAttackBoss(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    UpdateStats();
                }

                if (monster == null || !monster.IsAliveMonster())
                {
                    if (monster != null)
                    {
                        GameStatus = $"Vous avez vaincu {monster.Name}";
                        monster.UpdatePlayerXP(ActualPlayer);
                        ActualPlayer.AddToPokedex(monster);
                    }

                    if (ActualPlayer.IsAlivePlayer())
                    {
                        NbWawes++;
                        GameStatus += $"\n Vague actuelle: {NbWawes}";
                        monster = GetRandomMonster(monsters, NbWawes);
                        monster.ResetStats();
                        ActualPlayer.ResetStatsPlayer();
                        GameStatus += $"\n Un nouveau monstre apparaît : {monster.Name} ! Pour certaines raisons, il n'a pas pu vous attaquer...";
                        UpdateStats();
                    }
                }
            }
            else
            {
                Death();
            }
        }

        private void Attack3Clicked(object parameter)
        {
            GameStatus = "Attaque 3";

            if (ActualPlayer.IsAlivePlayer())
            {
                if (ActualPlayer.Attack.Any(attack => attack.Name == "FireBall"))
                {
                    AttackPlayer fireballAttack = ActualPlayer.Attack.First(attack => attack.Name == "FireBall");
                    if (ActualPlayer.Mana > fireballAttack.ManaCost)
                    {
                        ActualPlayer.CastAttack(fireballAttack, monster);
                        GameStatus = $"Vous avez lancé {fireballAttack.Name} et infligé {fireballAttack.Damage} points de dégâts au {monster.Name}!";
                    }
                    else
                    {
                        GameStatus = "Vous n'avez pas assez de mana !";
                    }
                }
                if (monster.IsAliveMonster())
                {
                    if (monster.Category == "common")
                    {
                        string monsterAttackResult = monster.PerformAttackCommon(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "rare")
                    {
                        string monsterAttackResult = monster.PerformAttackRare(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "epic")
                    {
                        string monsterAttackResult = monster.PerformAttackEpic(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Legendary")
                    {
                        string monsterAttackResult = monster.PerformAttackLegendary(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Boss")
                    {
                        string monsterAttackResult = monster.PerformAttackBoss(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    UpdateStats();
                }

                if (monster == null || !monster.IsAliveMonster())
                {
                    if (monster != null)
                    {
                        GameStatus = $"Vous avez vaincu {monster.Name}";
                        monster.UpdatePlayerXP(ActualPlayer);
                        ActualPlayer.AddToPokedex(monster);
                    }

                    if (ActualPlayer.IsAlivePlayer())
                    {
                        NbWawes++;
                        GameStatus += $"\n Vague actuelle: {NbWawes}";
                        monster = GetRandomMonster(monsters, NbWawes);
                        monster.ResetStats();
                        ActualPlayer.ResetStatsPlayer();
                        GameStatus += $"\n Un nouveau monstre apparaît : {monster.Name} ! Pour certaines raisons, il n'a pas pu vous attaquer...";
                        UpdateStats();
                    }
                }
            }
            else
            {
                Death();
            }
        }

        private void Attack4Clicked(object parameter)
        {
            GameStatus = "Attaque 4";

            if (ActualPlayer.IsAlivePlayer())
            {
                if (ActualPlayer.Attack.Any(attack => attack.Name == "Thunder"))
                {
                    AttackPlayer thunderAttack = ActualPlayer.Attack.First(attack => attack.Name == "Thunder");
                    if (ActualPlayer.Mana > thunderAttack.ManaCost)
                    {
                        ActualPlayer.CastAttack(thunderAttack, monster);
                        GameStatus = $"Vous avez lancé {thunderAttack.Name} et infligé {thunderAttack.Damage} points de dégâts au {monster.Name}!";
                    }
                    else
                    {
                        GameStatus = "Vous n'avez pas assez de mana !";
                    }
                }
                if (monster.IsAliveMonster())
                {
                    if (monster.Category == "common")
                    {
                        string monsterAttackResult = monster.PerformAttackCommon(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "rare")
                    {
                        string monsterAttackResult = monster.PerformAttackRare(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "epic")
                    {
                        string monsterAttackResult = monster.PerformAttackEpic(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Legendary")
                    {
                        string monsterAttackResult = monster.PerformAttackLegendary(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    else if (monster.Category == "Boss")
                    {
                        string monsterAttackResult = monster.PerformAttackBoss(ActualPlayer);
                        GameStatus += $" \n{monsterAttackResult}";
                    }
                    UpdateStats();
                }

                if (monster == null || !monster.IsAliveMonster())
                {
                    if (monster != null)
                    {
                        GameStatus = $"Vous avez vaincu {monster.Name}";
                        monster.UpdatePlayerXP(ActualPlayer);
                        ActualPlayer.AddToPokedex(monster);
                    }

                    if (ActualPlayer.IsAlivePlayer())
                    {
                        NbWawes++;
                        GameStatus += $"\n Vague actuelle: {NbWawes}";
                        monster = GetRandomMonster(monsters, NbWawes);
                        monster.ResetStats();
                        ActualPlayer.ResetStatsPlayer();
                        GameStatus += $"\n Un nouveau monstre apparaît : {monster.Name} ! Pour certaines raisons, il n'a pas pu vous attaquer...";
                        UpdateStats();
                    }
                }
            }
            else
            {
                Death();
            }
        }

        public void UsePotionPv(object parameter)
        {
            if (ActualPlayer.Inventory.PotionPv >= 1)
            {
                ActualPlayer.Inventory.PotionPv -= 1;
                ActualPlayer.addPlayerPv(20);
                UpdateStats();
            }
        }

        public void UsePotionMana(object parameter)
        {
            if (ActualPlayer.Inventory.PotionMana >= 1)
            {
                ActualPlayer.Inventory.PotionMana -= 1;
                ActualPlayer.addPlayerMana(20);
                UpdateStats();
            }
        }

        public void UseParchmentMana(object parameter)
        {
            if (ActualPlayer.Inventory.ParchmentMana >= 1)
            {
                ActualPlayer.Inventory.ParchmentMana -= 1;
                ActualPlayer.hasUsedParchmentMana = true;
                UpdateStats();
            }
        }

        public void UseParchmentPv(object parameter)
        {
            if (ActualPlayer.Inventory.ParchmentPv >= 1)
            {
                ActualPlayer.Inventory.ParchmentPv -= 1;
                ActualPlayer.hasUsedParchmentPv = true;
                UpdateStats();
            }
        }

        public void UpdateStats()
        {
            MonsterName = $"{monster.Name}";
            MonsterMana = $"{monster.Mana}";
            MonsterLife = $"{monster.Health}";
            PlayerMana = $"{ActualPlayer.Mana}";
            PlayerLife = $"{ActualPlayer.Pv}";
            EnemyImgSource = $"{monster.Img}";
            PotionPv = $"{ActualPlayer.Inventory.PotionPv}";
            PotionMana = $"{ActualPlayer.Inventory.PotionMana}";
            ParchmentMana = $"{ActualPlayer.Inventory.ParchmentMana}";
            ParchmentPv = $"{ActualPlayer.Inventory.ParchmentPv}";
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

        public void SaveGame(string fileName)
        {
            SaveData saveData = new SaveData
            {
                Player = ActualPlayer,
                Monster = monster
            };

            string json = JsonConvert.SerializeObject(saveData);
            System.IO.File.WriteAllText(fileName, json);
        }

        public void LoadGame(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                string json = System.IO.File.ReadAllText(fileName);
                SaveData saveData = JsonConvert.DeserializeObject<SaveData>(json);

                if (saveData != null)
                {
                    ActualPlayer.UpdatePlayerProperties(saveData.Player.Pv, saveData.Player.Mana, saveData.Player.Level, saveData.Player.ExperiencePoints, saveData.Player.XpRequiredForNextLevel, saveData.Player.originalHealth, saveData.Player.originalMana, saveData.Player.Wins, saveData.Player.Inventory, saveData.Player.Pokedex);
                    UpdateStats();
                    GameStatus = "La partie a été chargée avec succès !";
                }
                else
                {
                    GameStatus = "Il y a eu une erreur lors du chargement de la sauvegarde.";
                }
            }
            else
            {
                GameStatus = "Aucune sauvegarde trouvée.";
            }
        }

        private void SaveGameCommand(object parameter)
        {
            SaveGame("save.json");
        }

        private void LoadGameCommand(object parameter)
        {
            LoadGame("save.json");
        }
    }

}
