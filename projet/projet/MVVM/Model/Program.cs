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
    /*static void Main()
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

        MonsterBoss monsterBoss = new MonsterBoss("Rayquaza Shiny", 300, 150);
        monsterBoss.Attack2.AddRange(AttackMonstersBoss.AttackMonsterBoss.GenerateDefaultAttacksBoss());
        Console.WriteLine("Attaques du boss : ");
        foreach (var attack2 in monsterBoss.Attack2)
        {
            Console.WriteLine($"{attack2.Name} - Dommages : {attack2.Damage}, Co�t en mana : {attack2.ManaCost}");
        }
        Console.WriteLine();

        MonsterLegendary.InitLengendary();
        MonsterCommon.InitCommon();
        MonsterRare.InitRare();
        MonsterEpic.InitEpic();
    }*/
}