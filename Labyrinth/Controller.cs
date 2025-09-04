using Labyrinth.Exceptions;
using Labyrinth.LabyrinthElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class Controller
    {
        public LabyrinthModel Model { get; set; }
        public LabyrinthVue Vue { get; set; }

        public Controller(LabyrinthModel model, LabyrinthVue vue)
        {
            Model = model;
            Vue = vue;
        }
        public void Start() 
        {
            int playerCount = Model.PersonnageKey.Count;
            bool quit = false;
            Console.Clear();
            Vue.Print(Model);
            while (!quit)
            {
                // cki =  consoleKeyInfo. Hier speichere ich die Tasteninformationen die ich vom user erhalte (Readkey).
                // Ich prüfe ob die Tasten Control, shift und Q gedrückt sind.
                ConsoleKeyInfo cki = Console.ReadKey(true);
                bool quitCombination = cki.Modifiers.HasFlag(ConsoleModifiers.Control)
                    && cki.Modifiers.HasFlag(ConsoleModifiers.Shift)
                    && cki.Key == ConsoleKey.Q;

                
                // fals nicht gedrückt geht das Spiel weiter
                if (!quitCombination)
                {
                    // Ich prüfe ob eine Pfeiltaste gedrückt wurde und assoziiere diese mit einem Richtungswert meines Enums Direction.
                    bool movement = false;
                    Direction direction = Direction.NORD;
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Direction.NORD;
                            movement = true;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Direction.SUD;
                            movement = true;
                            break;
                        case ConsoleKey.RightArrow:
                            direction = Direction.EST;
                            movement = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = Direction.OUEST;
                            movement = true;
                            break;
                        case ConsoleKey.Tab:
                            Model.ActivePersonnage();
                            break;

                            // ich erstelle eine lokale variable key die den Wert von cki.key erhält.
                            // diese Variable verwende ich, um zu prüfen ob meine Personnageliste einen Wert für den gedrückten Buchstaben enthält.
                            // Falls ja, greift der case und ich rufe die Methode ActivePersonnage(Buchstabe)
                        case var key when Model.PersonnageKey.Contains((char)key):
                            Model.ActivePersonnage((char)key);
                            break;
                        default:
                            // Keine Pfeiltaste gedrückt? Keine weitere Aktion, der Loop wiederholt sich.
                            break;
                    }
                    Console.Clear();
                    Vue.Print(Model);
                    
                    // Bei gültiger Pfeiltaste
                    if (movement)
                    {
                        Personnage personnageActive = Model.PersonnagesMap[Model.PersonnageKey[Model.PersonnageActif]];
                        // Ich speichere die alte Position, um die Spielfigur ggf auf diese zurückzusetzen, solte die nachbarposition nicht gültig sein
                        PositionLabyrinth? oldPos =  personnageActive.Position;
                        // Versuch die Figur auf das gewählte Feld zu bewegen.
                        try
                        {

                            Model.Move(personnageActive, direction);
                            Console.Clear();
                            Vue.Print(Model);

                        }
                        // Bei Mauer, Spielfigur wird zurückgesetzt.
                        catch (LabyrinthException eMur)
                        {
                            personnageActive.Position = oldPos;
                            Model[oldPos].Content = personnageActive;
                            Console.Clear();
                            Vue.Print(Model);
                            Console.WriteLine(eMur.Message);
                        }
                        // Figur verlässt Feld. Spielende.
                        catch (OutOfLabyrinthException eBound)
                        {
                            
                            Model[oldPos].Content = null;
                            Model.ActivePersonnage();
                            
                            playerCount--;
                            if (playerCount == 0) 
                            {
                                
                                quit = true;
                            }

                            Console.Clear();
                            Vue.Print(Model);
                            Console.WriteLine(eBound.Message);
                        }
                    }
                }
                else
                {
                    quit = true;
                }   
            }
            if (!quit) { Console.WriteLine("Congratulations!"); }
        }
    }
}
