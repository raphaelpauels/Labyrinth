using Labyrinth.Exceptions;
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

        public PositionLabyrinth this[Direction direction] { 
            get
            {
                // Switch Expression
                // Ich erstelle einen Indexer für das Attribut direction in der Klasse PositionLabyrinth. 
                // Dies erlaubt mir, für einen Index direction in PositionLabyrinth einen Wert aufzurufen. 
                // In diesem Fall ist der Wert die neue Instanzierung einer PositionLabyrinth, die je nach direction das benachbarte Feld belegt.
                return direction switch
                {
                    Direction.NORD => new PositionLabyrinth(Line - 1, Column),
                    Direction.SUD => new PositionLabyrinth(Line + 1, Column),
                    Direction.EST => new PositionLabyrinth(Line, Column + 1),
                    Direction.OUEST => new PositionLabyrinth(Line, Column - 1),
                    _ => throw new LabyrinthException("Cannot find suitable position.")
                };


                // Switch Instruction
                // Wird ersetzt durch eine Switch Expression die moderner und einfacher zu lesen ist.
                /*
                switch (direction)
                {
                    case Direction.NORD:
                        return new PositionLabyrinth(this.Line - 1, this.Column);
                        
                    case Direction.SUD:
                        return new PositionLabyrinth(this.Line + 1, this.Column);
                    case Direction.EST:
                        return new PositionLabyrinth(this.Line, this.Column +1);

                    case Direction.OUEST:
                        return new PositionLabyrinth(this.Line, this.Column -1);
                    default:
                        throw new LabyrinthException("Cannot find suitable position.");

                }
                */
            }
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
