using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
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
    }
}
