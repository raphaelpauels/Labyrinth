using Labyrinth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Exceptions;

namespace Labyrinth.LabyrinthElements
{
    internal class Personnage : ILabyrinthObject
    {
        public char Symbole { get; }
        public PositionLabyrinth? Position;

        public ICollection<ILabyrinthObject>? Bag;

       public Personnage(char symbole) 
        {
            Symbole = symbole;
            Bag = new List<ILabyrinthObject>();
        }
        public void Visite(Personnage personnage)
        {
            foreach (Clef clef in personnage.Bag)
            {
                Bag.Add(clef);
                
            }
            personnage.Bag.Clear();
                        
            throw new LabyrinthException($"You gave {this.Symbole} your keys.");
        }
    }
}
