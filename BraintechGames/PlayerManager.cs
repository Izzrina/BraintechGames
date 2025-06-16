using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Diese Klasse dient dazu, Benutzer anzulegen, Einzuloggen, den aktuellen Score zu speichern und Benutzer wieder löschen zu können */

namespace BraintechGames
{
    internal static class PlayerManager
    {
        /*
         * Benutzer hinzufügen
         * Liest die gespeicherte Liste aus
         * vergleicht ob der Benutzer bereits vorhanden ist
         * Wenn nicht, dann wird er neu erstellt
         */
        public static Player AddNewPlayer()
        {
            //Liste der bereits bestehenden Benutzer laden
            List<Player> players = PlayerStorage.LoadPlayers();

            while (true)
            {
                Console.Write("Enter username: ");
                string name = Console.ReadLine();
                if (name == "exit") return null;
                bool registered = players.Any(p => p.Username == name);
                if (!registered && !string.IsNullOrWhiteSpace(name))
                {
                    Player player = new Player(name, 0, 0);
                    players.Add(player);
                    PlayerStorage.SavePlayers(players);
                    return player;
                }
                Console.WriteLine("This username is already taken. Please choose a different one or type exit to leave\n");
            }
        }

        public static Player GetPlayer()
        {
            List<Player> players = PlayerStorage.LoadPlayers();
            while (true)
            {
                Console.Write("Enter username: ");
                string name = Console.ReadLine();
                if (name == "exit") return null;
                Player player = players.Find(p => p.Username == name);
                if (player != null)
                {
                    return player;
                }
                Console.WriteLine("Unknown username Please choose a different one or type exit to leave\n");
            }
        }

        public static void SavePlayerMathScore(Player player, int score)
        {
            List<Player> players = PlayerStorage.LoadPlayers();
            Player playerInList = players.Find(p => p.Username == player.Username);
            if (playerInList != null)
            {
                playerInList.AddMathScore(score);
                PlayerStorage.SavePlayers(players);
            }
        }
        public static void SavePlayerLogicScore(Player player, int score)
        {
            List<Player> players = PlayerStorage.LoadPlayers();
            Player playerInList = players.Find(p => p.Username == player.Username);
            if (playerInList != null)
            {
                playerInList.AddLogicScore(score);
                PlayerStorage.SavePlayers(players);
            }
        }
    }
}
