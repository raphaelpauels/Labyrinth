using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class Personnage : ILabyrinthObject
    {
        public char Symbole => 'O';
        public PositionLabyrinth? Position;
        
    }
}
