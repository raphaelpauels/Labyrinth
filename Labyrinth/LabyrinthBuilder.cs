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
    internal class LabyrinthBuilder
    {
        // Ich erstelle ein Dictionary das einen Key mit einem Create delegate verbindet (welches eine Methode repräsentiert).
        // Das ist hilfreich wenn ich einen Input lese und den entsprechenden Delegate nachschlagen und ausführen kann.
        private Dictionary<char, Create> factories;

        // Ich erstelle eine Delegatetype der eine Methode ohne Parameter repräsentiert,
        // Und ein IElementLabyrinth returned.
        delegate IElementLabyrinth Create();

        // Alternative Verwendung von Delegate, Länger als eine Lambda funktion im Dictionary zu verwenden, bei längerem Code aber besser.
        // Ich erstelle eine Methode BuildMur die keine Parameter erwartet und eine neues Object Mur instanziert.
        // Diese MEthode kann ich in meinem Dictionary verwenden, da es die Kriterien des Delegate erfüllt.
        IElementLabyrinth BuildMur() => new Mur();

        public LabyrinthBuilder()
        {
            // Wenn ich einen LabyrinthBuilder instanziere möcht ich dass dieser ein Dictionary factories enthält.
            factories = new Dictionary<char, Create>();
            // Ich definiere 2 factory_EintrÄge, die ihr Zeichen mit einer Create Implemnentierung  verbinden.
            // Da mein delegate eine Funktion ohne Parameter repräsentiert und ein IElement zurück gibt kann ich eine Lambda funktion verwenden die eine neue Instanz eines IElements erstellt.
            factories.Add('*', BuildMur);
            factories.Add('.', () => new Piece());
            //factories.Add('O', () => new Piece(new Personnage(c)));
            factories.Add('_', () => new Porte());
            factories.Add('F', () => new Piece(new Clef()));
        }

        public LabyrinthModel FileToModel(string filePath, string modelName)
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                using StreamReader sr = new StreamReader(filePath);

                //Read the first line of text
                line = sr.ReadLine();

                LabyrinthModel model = new(modelName);

                //Continue to read until you reach end of file
                int lig = 0;
                while (line != null)
                {
                    int col = 0;
                    foreach (char c in line)
                    {
                        // Ich iteriere durch jede Zeile und darin durch jedes Zeichen.
                        // Für jedes Nicht-Leerzeichen rufe ich das Delegate aus factories auf, das mit diesem Zeichen verknüpft ist,
                        // und speichere das erzeugte Element im Modell im Index mit PositionLabyrinth.
                        if (c != ' ')
                        {
                            // Ich teste ob ich ein gültiges Delegate für das gelesene Symbole definiert habe.
                            // falls nicht verwende ich als standart das delegate für Piece.
                            if (factories.TryGetValue(c, out var create))
                            {
                                model[new PositionLabyrinth(lig, col)] = create();

                                // Ich prüfe ob es sich um ein Buchstabensymbol handelt (F ist für Schlüssel reserviert).
                                // Ich benutze dafür eine STATISCHE Methode der Klasse char. 
                                // Deshalb ruft die Klasse char die Methode auf, und nicht die variable c.
                            }else if (Char.IsLetter(c) && c != 'F')
                            {
                                // Ich muss create mit einer neuen Methode neu zuweisen. Ansonsten wäre create null, da es sich auf das TryGetValue von vorher bezieht.
                                // Ich lande hier, weil mein create vorher null gegeben hatt (es bestand kein Eintrag in factories.)
                                create = () => new Piece(new Personnage(c));
                                var piece = create();
                                model[new PositionLabyrinth(lig, col)] = piece;
                                model.PersonnageKey.Add(c);
                                model.PersonnagesMap.TryAdd(c, (Personnage)piece.Content);
                            }
                            else model[new PositionLabyrinth(lig, col)] = factories['.']();
                        }
                        col++;
                    }

                    //Read the next line
                    line = sr.ReadLine();
                    lig++;
                }
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                throw new Exception("FileToModel failed", e);
                 
            }
        }
    }
}
