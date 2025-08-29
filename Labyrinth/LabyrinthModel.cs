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
        public Personnage Personnage { get; set; }

        private SortedDictionary<PositionLabyrinth, IElementLabyrinth> grille;

        // Ich definiere einen Indexer in LabyrinthModel, der es erlaubt dass LabyrinthModel mit PositionLabyrinth indexiert werden kann.
        // Die Indexe enthalten ihrersetis IElementLabyrinth Objekte.
        public IElementLabyrinth this[PositionLabyrinth position] { 
            get { return grille[position]; } 
            set 
            { 
                // Ich checke ob der Wert in der aktuellen Position den Content Personnage hat.
                // Falls ja muss ich das im Modell festhalten und die Position erfassen.
                // In der Klasse Personnage ist festgelegt dass diese immer eine Position haben muss.
                if (value.Content is Personnage p)
                {
                    Personnage = p;
                    Personnage.Position = position;
                }
                grille[position] = value; } 
        }

        public LabyrinthModel(string nom)
        {
            grille = new SortedDictionary<PositionLabyrinth, IElementLabyrinth>();
            Nom = nom;
        }

        // Erlaubt es von Aussen zu checken, ob ein Model einen Wert für einen Key gespeichert hat. Falls ja, gibt es diesen Wert als Typ IElementLabyrinth wieder.
        public bool TryGetValue(PositionLabyrinth position, out IElementLabyrinth element) => grille.TryGetValue(position, out element);

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
