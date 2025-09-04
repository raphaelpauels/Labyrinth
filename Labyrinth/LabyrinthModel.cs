using Labyrinth.Exceptions;
using Labyrinth.Interfaces;
using Labyrinth.LabyrinthElements;
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

        public Dictionary<char, Personnage> PersonnagesMap = new Dictionary<char, Personnage>();
        public List<char> PersonnageKey = new List<char>();

        public int PersonnageActif { get; set; }

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
            PersonnageActif = 0;
        }

        // Methode mit der ich meine Person durch das Labyrinth bewege.
        public void Move(Personnage personnage, Direction direction)
        {
            // Ich speichere die aktuelle Position von meiner Person.
            PositionLabyrinth currentPos = personnage.Position;

            // Ich prüfe ob ich einen Eintrag für die benachbarte Position (Indexer von PositionLabyrinth currentPos greift.
            // Ich erstelle eine neue PositionLabyrinth für den Eintrag direction (Enum Direction).
            if (grille.ContainsKey(currentPos[direction]))
            {
                // falls einen passenden Schlüssel (Position) in meinem grid gefunden wird
                // lösche ich den Inhalt den Content der jetzigen Position (da der Content weiter wander)
                // Die Position von personnage erhält die Postion des Nachbarfeld.
                grille[currentPos].Content = null;
                personnage.Position = currentPos[direction];
                //try
                //{
                // Die Person klopft an der neuen Position an, und schaut welches Element dort liegt.
                // Eine Fehlermeldung tritt auf wenn das Element eine Mauer ist, wird in Controller gehandelt.
                grille[personnage.Position].Visite(personnage);

                //}
                //catch (LabyrinthException e)
                //{
                //    Console.WriteLine(e.Message);
                //}

            }else 
            {
                // Falls keine gültige Pos gefunden wird, wird die Pos von Person gelöscht und eine Fehlermeldung angezeigt.
                personnage.Position = null;
                throw new OutOfLabyrinthException($"{PersonnageKey[PersonnageActif]} est sorti du Labyrinthe"); 
            }        
        }

        // PersonnageActif dient als Zähler von PersonnageKey.
        // Diese Methode erlaubt es mir durch die möglichen Indexe zu gehen.
        // Wenn mein Index den Wert von PersonnageKey.Count erreicht wird der Index durch das Modulo auf 0 gesetzt.
        // Beispiel (4 Einträge): Rückgabefolge = 0, 1, 2, 3, 0, 1, ...
        public int ActivePersonnage()
        {
           PersonnageActif = (PersonnageActif+1) % PersonnageKey.Count;
            return PersonnageActif;
        }

        public int ActivePersonnage(char symbole)
        {
            PersonnageActif = PersonnageKey.IndexOf(symbole);
            return PersonnageActif;
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
