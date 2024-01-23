// using Players;
// using AttackPlayers;
// using MonstersCommon;
// using MonstersRare;
// using MonstersEpic;
// using MonstersLegendary;
// using AttackMonstersCommon;
// using AttackMonstersRare;
// using AttackMonstersEpic;
// using AttackMonstersLegendary;
// using Inventorys;
// using System.Collections.Generic;

// public class Program
// {
// 	static void Main()
// 	{
// 		Player player = new Player("joueur", 40, 40, 1);
//         //init attaque pour le joueur
//         player.Attack.AddRange(AttackPlayer.GenerateDefaultAttacksPlayer());
//         // affiche attaque du player
//         Console.WriteLine("Attaques du player :");
//         foreach (var attack in player.Attack)
//         {
//             Console.WriteLine($"{attack.Name} - Dommages : {attack.Damage}, Co�t en mana : {attack.ManaCost}");
//         }

//         MonsterLegendary.InitLegendary();
//         MonsterCommon.InitCommon();
//         MonsterRare.InitRare();
//         MonstersEpic.initEpic();
//     }
// }