using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class LabyrinthVue
    {
        public LabyrinthModel labyrinthModel = new();
        

        public void Affiche(LabyrinthModel model, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(model.Nom);
        }
    }
}
