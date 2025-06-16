using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;

/*Diese Klasse dient rein zum Speichern und Abrufen von Benutzern über ein Json-File*/

namespace BraintechGames
{
    internal static class PlayerStorage
    {
        /*
         * Das File als Konstante gesetzt, weil nicht zur Laufzeit veränderbar
         */
        private const string FilePath = "Data/players.json";


        /*
         * Neuen Benutzer hinzufügen
         */

        public static List<Player> LoadPlayers()
        {
            /*
             * Wenn die Datei nicht gefunden wird, wird eine leere Liste zurückgegeben
             */
            if (!File.Exists(FilePath))
            {
                //Console.WriteLine("Spielerdatei nicht gefunden");
                return new List<Player>();
            }
            /*
             * Den Inhalt des Files auslesen und in wenn gültiges JSON in eine Liste umwandeln, ansonsten leere Liste ausgeben
             */
            string json = File.ReadAllText(FilePath);
            //Console.WriteLine("Datei geladen");
            return JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
        }

        public static void SavePlayers(List<Player> players)
        {
            try
            {
                string json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
                //Console.WriteLine("JSON to save:\n" + json);
                //Console.WriteLine($"Saved {players.Count} players to {FilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving players: {ex.Message}");
            }
        }
    }
}
