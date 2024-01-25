using Players;
using AttackPlayers;
using MonstersCommon;
using MonstersRare;
using MonstersEpic;
using MonstersLegendary;
using MonstersBoss;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Player player = new Player("joueur", 40, 40, 1);
        //init attaque pour le joueur
        player.Attack.AddRange(AttackPlayer.GenerateDefaultAttacksPlayer());
        // affiche attaque du player
        Console.WriteLine("Attaques du player :");
        foreach (var attack in player.Attack)
        {
            Console.WriteLine($"{attack.Name} - Dommages : {attack.Damage}, Co�t en mana : {attack.ManaCost}");
        }
        Console.WriteLine();

        int NbDeVague = 1;
        Random random = new Random();

        while (player.IsAlivePlayer())
        {
            Console.WriteLine($"Vague {NbDeVague}");

            // Liste de tous les types de monstres
            List<object> possibleMonsters = new List<object>();

            // Condition for common monsters
            if (NbDeVague <= 10)
            {
                possibleMonsters.Add(MonsterCommon.InitCommon());
            }
            // Condition for rare monsters
            else if (NbDeVague <= 20)
            {
                // 50% chance for rare, 50% chance for common
                if (random.Next(2) == 0)
                {
                    possibleMonsters.Add(MonsterRare.InitRare());
                }
                else
                {
                    possibleMonsters.Add(MonsterCommon.InitCommon());
                }
            }
            else if (NbDeVague <= 30)
            {
                possibleMonsters.Add(MonsterRare.InitRare());
            }
            else if (NbDeVague <= 40)
            {
                // 50% chance for rare, 50% chance for epic
                if (random.Next(2) == 0)
                {
                    possibleMonsters.Add(MonsterRare.InitRare());
                }
                else
                {
                    possibleMonsters.Add(MonsterEpic.InitEpic());
                }
            }
            else if (NbDeVague <= 50)
            {
                possibleMonsters.Add(MonsterEpic.InitEpic());
            }
            else if (NbDeVague <= 60)
            {
                // 50% chance for lengendary, 50% chance for epic
                if (random.Next(2) == 0)
                {
                    possibleMonsters.Add(MonsterLegendary.InitLengendary());
                }
                else
                {
                    possibleMonsters.Add(MonsterEpic.InitEpic());
                }
            }
            else if (NbDeVague <= 70)
            {
                possibleMonsters.Add(MonsterLegendary.InitLengendary());
            }
            // Condition for legendary, and boss monsters
            else if (NbDeVague >= 71)
            {
                if (random.Next(5) == 0)
                {
                    possibleMonsters.Add(new MonsterBoss("Rayquaza Shiny", 300, 150));
                }
                else
                {
                    possibleMonsters.Add(MonsterLegendary.InitLengendary());
                }
            }

            // Choix aléatoire d'un monstre parmi les possibilités
            object randomMonster = possibleMonsters[random.Next(possibleMonsters.Count)];

            // Afficher le type de monstre en fonction du type obtenu
            if (randomMonster is MonsterCommon commonMonster)
            {
                Console.WriteLine($"Un monstre commun apparaît: {commonMonster.Name}");
                if (!commonMonster.IsAliveMonsterCommon())
                {
                    NbDeVague++;
                }
            }
            else if (randomMonster is MonsterRare rareMonster)
            {
                Console.WriteLine($"Un monstre rare apparaît: {rareMonster.Name}");
                if (!rareMonster.IsAliveMonsterRare())
                {
                    NbDeVague++;
                }
            }
            else if (randomMonster is MonsterEpic epicMonster)
            {
                Console.WriteLine($"Un monstre épique apparaît: {epicMonster.Name}");
                if (!epicMonster.IsAliveMonsterEpic())
                {
                    NbDeVague++;
                }
            }
            else if (randomMonster is MonsterLegendary legendaryMonster)
            {
                Console.WriteLine($"Un monstre légendaire apparaît: {legendaryMonster.Name}");
                if (!legendaryMonster.IsAliveMonsterLegendary())
                {
                    NbDeVague++;
                }
            }
            else if (randomMonster is MonsterBoss bossMonster)
            {
                Console.WriteLine($"Le boss apparaît: {bossMonster.Name}");
                if (!bossMonster.IsAliveBoss())
                {
                    NbDeVague++;
                }
            }

            // Simulez le combat avec le monstre, ajustez les détails en fonction de votre logique de jeu

            //NbDeVague++;
        }

        Console.WriteLine("Le joueur a été vaincu. Fin de la partie.");
    }

}