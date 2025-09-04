using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Interfaces 
{
    internal interface IElementLabyrinth : ISymbole, IPersonnageVisitable
    {
        ILabyrinthObject Content { get; set; }
    }
}
