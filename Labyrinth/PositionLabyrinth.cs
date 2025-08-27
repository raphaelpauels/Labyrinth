using System;
using System.Collections.Generic;
using System.Linq;
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

        public int CompareTo(PositionLabyrinth? other)
        {
            if (other == null) return 1;

            if (Line != other.Line)
                return Line.CompareTo(other.Line);

            return Column.CompareTo(other.Column);
        }

        // For equality checks
        public override bool Equals(object? obj)
        {
            if (obj is not PositionLabyrinth other) return false;
            return Line == other.Line && Column == other.Column;
        }

        public override int GetHashCode()
        {
            // Combine Line and Column into a single hash
            return HashCode.Combine(Line, Column);
        }
    }

}
