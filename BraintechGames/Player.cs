using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/*Die Klasse Spieler soll nur über den Konstruktor gesetzt werden können, das heißt dass Benutzername und Passwort
nach dem Erstellen nicht mehr veränderlich sind. Der Score wird rein über eine Methode verändert.
*/
namespace BraintechGames
{
    internal class Player

    {
        //Öffentliche Property (nur Getter)
        public string Username { get; }
        public int MathScore { get; set; }
        public int LogicScore { get; set; }
        public int TotalScore => MathScore + LogicScore;

        //Konstruktor
        [JsonConstructor]
        public Player(string username, int mathScore, int logicScore)
        {
            Username = username;
            MathScore = mathScore;
            LogicScore = logicScore;
        }

        //Methode um den Score zu setzen
        public void AddMathScore(int points)
        {
            MathScore += points;
        }
        public void AddLogicScore(int points)
        {
            LogicScore += points;
        }
    }
}
