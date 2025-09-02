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
            bool quit = false;
            Vue.Print(Model);
            while (!quit)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                bool quitCombination = cki.Modifiers.HasFlag(ConsoleModifiers.Control)
                    && cki.Modifiers.HasFlag(ConsoleModifiers.Shift)
                    && cki.Key == ConsoleKey.Q;


                if (!quitCombination)
                {
                    bool validInput = true;
                    Direction direction = Direction.NORD;
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Direction.NORD;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Direction.SUD;
                            break;
                        case ConsoleKey.RightArrow:
                            direction = Direction.EST;
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = Direction.OUEST;
                            break;
                        default:
                            validInput = false;
                            break;
                    }

                    if (validInput)
                    {
                        PositionLabyrinth? oldPos = Model.Personnage.Position;
                        try
                        {

                            Model.Move(Model.Personnage, direction);
                            Console.Clear();
                            Vue.Print(Model);

                        }
                        catch (LabyrinthException eMur)
                        {
                            Model.Personnage.Position = oldPos;
                            Model[oldPos].Content = Model.Personnage;
                            Console.Clear();
                            Vue.Print(Model);
                            Console.WriteLine(eMur.Message);
                        }
                        catch (OutOfLabyrinthException eBound)
                        {
                            Console.WriteLine(eBound.Message);
                            quit = true;
                            
                        }
                    }
                }
                else
                {
                    quit = true;
                }   
            } 
        }
    }
}
