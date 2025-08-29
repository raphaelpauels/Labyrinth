using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class LabyrinthModel :IEnumerable<KeyValuePair<PositionLabyrinth, IElementLabyrinth>>
    {
        public string Nom { get; set; }

        private SortedDictionary<PositionLabyrinth, IElementLabyrinth> grille;

        // Ich definiere einen Indexer in LabyrinthModel, der es erlaubt dass LabyrinthModel mit PositionLabyrinth indexiert werden kann.
        // Die Indexe enthalten ihrersetis IElementLabyrinth Objekte.
        public IElementLabyrinth this[PositionLabyrinth position] { 
            get { return grille[position]; } 
            set { grille[position] = value; } 
        }

        public LabyrinthModel(string nom)
        {
            grille = new SortedDictionary<PositionLabyrinth, IElementLabyrinth>();
            Nom = nom;
        }

        public void Print()
        {
            // Ich möcht das Grid drucken. Beim Einlesen des Grids aus dem File habe ich Leerzeichen jedoch übersprungen.
            // Deshalb muss ich nun zählen was die max Dimensionen meines Grids sind um fehlende Position mit Leerzeichen zu füllen.
            int maxLine = 0;
            int maxColumn = 0;
            foreach (var entry in grille)
            {
                if (entry.Key.Line > maxLine) { maxLine = entry.Key.Line; };
                if (entry.Key.Column > maxColumn) { maxColumn = entry.Key.Column; };
            }

            // Anschlissend gehe ich meine Kollektion durch und schaue ob ich für jede Lig/Col Kombination ein Symbol gespeochert habe.
            // Falls nicht, drucke ich ein Leerzeichen. Wenn ich meinen maximale Kolonnenindex erreicht habe, wechsle ich die Linie.
            // Dies mache ich, bis ich die maximale Linie erreicht habe.
            for (int lig = 0; lig <= maxLine; lig++)
            {
                for (int col = 0; col <= maxColumn; col++)
                {
                    if (!grille.ContainsKey(new PositionLabyrinth(lig, col))) { Console.Write(' '); }
                    else { Console.Write(grille[new PositionLabyrinth(lig, col)].Symbole); }
                }
                Console.WriteLine();
            }
        }

        // Um über alle Key-Value-Paare in meinem Dictionary zu iterieren,
        // gebe ich hier den Enumerator des internen Dictionaries zurück.
        public IEnumerator<KeyValuePair<PositionLabyrinth, IElementLabyrinth>> GetEnumerator()
        {
           return grille.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
