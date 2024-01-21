using Monsters;
using Players;
using AttackManaPlayers;
using AttackPlayers;

public class Program
{
    static void Main()
    {
        Player player = new Player("joueur", 40, 40, 1);
        player.AttackManaPlayers.Add(new AttackManaPlayer("FireBall", 25, 10));
        player.AttackManaPlayers.Add(new AttackManaPlayer("Thunder", 30, 15));
        player.AttackPlayers.Add(new AttackPlayer("coup de point", 10));
        player.AttackPlayers.Add(new AttackPlayer("coup de pied", 10));
    }
}