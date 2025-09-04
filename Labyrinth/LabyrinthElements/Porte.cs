using Labyrinth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Exceptions;

namespace Labyrinth.LabyrinthElements
{
    internal class Porte : IElementLabyrinth
    {
        public ILabyrinthObject Content { get; set; }

        private bool _open;

        public char Symbole
        {
            get
            {
                // When Piece keinen Content definiert bekommen hat, gibt er den Default Wert '.' wieder.
                // Ansonsten gibt er den definierten werden von Content wieder.
                // Da Content den Typ ILabyrinthObject hat, und dieser Typ ein Erbe von Isymbole ist, haben wir Zugriff auf die Symbol Eigenschaft, die in ISymbole definiert ist.
                if (Content == null)
                {
                    if (_open)
                    {
                        return '|';
                    }else
                    {
                        return '_';
                    }
                }
                else return Content.Symbole;
            }
        }

        public Porte() 
        {
            _open = false;
        }

        public void Visite(Personnage personnage)
        {
            if (!_open)
            {

                // Nimm die erste gefundene Schlüssel-Instanz
                Clef? clef = personnage.Bag.OfType<Clef>().FirstOrDefault();
                if (clef != null)
                {
                    this.OpenDoor();
                    personnage.Bag.Remove(clef); // entfernen
                    //Content = personnage;
                }
                else throw new LabyrinthException("Cette porte est fermée à clef!");


            }
            Content = personnage;

        }

        public void OpenDoor()
        {
            _open = true;
        }
    }
}
