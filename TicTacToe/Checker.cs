using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum Color
    {
        Red,
        Black
    }

    public struct Coords
    {
        public int X;
        public int Y;
    }

    public class Checker
    {
        public Color Color { get; }

        public bool King { get; set; }

        public Coords Coords;
        
        public Checker(Color color, int x, int y)
        {
            Color = color;
            Coords.X = x;
            Coords.Y = y;
        }

        public Checker(Color color, bool king, int x, int y)
        {
            Color = color;
            King = king;
            Coords.X = x;
            Coords.Y = y;
        }

        public override string ToString()
        {
            return $"{Color} {King} {Coords.X} {Coords.Y}";
        }
    }
}
