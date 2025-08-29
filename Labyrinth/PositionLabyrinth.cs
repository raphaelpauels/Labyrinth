using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class PositionLabyrinth : IComparable<PositionLabyrinth>
    {
        public int Line { get; }
        public int Column { get; }

        public PositionLabyrinth(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public int CompareTo(PositionLabyrinth other) =>
        
            /////++++ Shortest Version
            ///Erste Klammer: Line = other.Line? --> dann passert was nach den ? steht.
            ///nach Fragezeichen: Column mit other.Column verlgieche, sind Linie mit Linie.
            (Line == other.Line) ? Column.CompareTo(other.Column) : Line.CompareTo(other.Line);

            ////++++Shorter Version
            //if (Line.CompareTo(other.Line) == 0)
            //{
            //    return Column.CompareTo(other.Line);
            //}
            //else { return Line.CompareTo(other.Column); }

            ////+++++Long Version+++++
            //if (Line == other.Line)
            //{   if (Column > other.Column) { return 1; }
            //    if (Column < other.Column) { return -1; }               
            //}
            //else if ( Line < other.Line) { return -1; }
            //else if (Line > other.Line) { return 1; }
            //else { return 0; }
        

        public override bool Equals(object? obj)
        {
            if (obj is PositionLabyrinth other)
            {
                return other.Line == Line && other.Column == Column; 
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Line, Column);
            
        }
    }

}
