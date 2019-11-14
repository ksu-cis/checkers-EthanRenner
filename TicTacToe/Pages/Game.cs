using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Pages
{
    public class Game
    {
        public Checker[,] Board = new Checker[8, 8];

        public Color CurrentTurn { get; set; }

        public bool GameOn { get; set; }

        public Game()
        {
            GameOn = true;
            for (int x = 0; x < 8; x += 2)
            {
                Board[x, 0] = new Checker(Color.Black, x, 0);
                Board[x, 2] = new Checker(Color.Black, x, 2);
                Board[x+1, 1] = new Checker(Color.Black, x+1, 1);

                Board[x, 6] = new Checker(Color.Red, x, 6);
                Board[x + 1, 7] = new Checker(Color.Red, x + 1, 7);
                Board[x + 1, 5] = new Checker(Color.Red, x + 1, 5);
            }
            CurrentTurn = Color.Red;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GameOn.ToString());
            sb.AppendLine(CurrentTurn.ToString());
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (Board[x,y] != null)
                    {
                        sb.AppendLine(Board[x, y].ToString());
                    }
                }
            }
            return sb.ToString();
        }

        public static Game Deserialize(string state)
        {
            Game game = new Game();
            string[] lines = state.Split('\n');
            game.GameOn = bool.Parse(lines[0]);
            game.CurrentTurn = (Color) Enum.Parse(typeof(Color), lines[1]);
            game.Board = new Checker[8, 8];
            for (int i = 2; i < lines.Length-1; i++)
            {
                string[] parts = lines[i].Split(' ');
                Color color = (Color)Enum.Parse(typeof(Color), parts[0]);
                bool king = bool.Parse(parts[1]);
                int x = int.Parse(parts[2]);
                int y = int.Parse(parts[3]);
                game.Board[x, y] = new Checker(color, king, x, y);
            }
            return game;
        }
    }
}
