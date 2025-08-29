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
        public string Message => "loaded succesfully!";
        public void Affiche(LabyrinthModel model)
        {
            Console.WriteLine(model.Nom);
            model.Print();
        }
    }
}
