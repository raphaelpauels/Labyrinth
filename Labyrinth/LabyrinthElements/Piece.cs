using Labyrinth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.LabyrinthElements
{
    internal class Piece : IElementLabyrinth
    {
        public char Symbole
        {
            get
            {
                // When Piece keinen Content definiert bekommen hat, gibt er den Default Wert '.' wieder.
                // Ansonsten gibt er den definierten werden von Content wieder.
                // Da Content den Typ ILabyrinthObject hat, und dieser Typ ein Erbe von Isymbole ist, haben wir Zugriff auf die Symbol Eigenschaft, die in ISymbole definiert ist.
                if (Content == null)
                {
                    return '.';
                }
                else return Content.Symbole;
            }
        }

        public ILabyrinthObject Content { get; set; }
        public Piece() { }
        public Piece(ILabyrinthObject content)
        {
            Content = content;
        }

        // Wenn die Person durch das Labyrinth wandert und eine Postion mit Objekt Piece belegt, sollte
        // Content dieses Piece durch das objekt Person ersetzt werden.
        public void Visite(Personnage personnage)
        {

            switch (Content)
            {
                case Clef clef:
                    clef.Visite(personnage);
                    break;
                case Personnage p:
                    p.Visite(personnage);
                    break;
            }

            //if (Content is Clef clef)
            //{
            //    clef.Visite(personnage);
            //}

            Content = personnage;
            
        }
    }
}
