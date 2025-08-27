using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class Mur : IElementLabyrinth
    {
        public char Symbole { get; }

        public Mur()
        {
            Symbole = '*';
        }

    }
}
