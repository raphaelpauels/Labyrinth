using Labyrinth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.LabyrinthElements
{
    internal class Clef : ILabyrinthObject
    {
        public char Symbole => 'f';
        public PositionLabyrinth? Position;

        public ICollection<ILabyrinthObject>? Bag;

       
        public void Visite(Personnage personnage)
        {
            personnage.Bag.Add(new Clef());
        }
    }
}
