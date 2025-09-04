using Labyrinth.Exceptions;
using Labyrinth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.LabyrinthElements
{
    internal class Mur : IElementLabyrinth
    {
        public char Symbole => '*';

        public ILabyrinthObject Content { 
            get => null; 
            set => throw new LabyrinthException("Un mur ne peut pas contenir un object."); }

        public void Visite(Personnage personnage)
        {
            throw new LabyrinthException("Les personnages ne traversent pas les murs.");
        }
    }

}
