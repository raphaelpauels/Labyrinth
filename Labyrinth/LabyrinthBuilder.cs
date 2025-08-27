using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class LabyrinthBuilder
    {

        private Dictionary<string, LabyrinthModel> labyrinths = new();
        public LabyrinthModel this[string name]
        {
            get => labyrinths[name];  // when you do builder["model1"]
            set => labyrinths[name] = value;
        }

    public string model1=
            """
            ---------------------
            |                   |
            |                   |
            |                   |
            |                   |
            |                   |
            ---------------------
            """
            ;
    }
}
