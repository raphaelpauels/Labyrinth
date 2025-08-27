using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class LabyrinthModel
    {
        public string Nom { get; set; }

        public Dictionary<PositionLabyrinth, IElementLabyrinth> grille;
        public LabyrinthModel() { }
        public LabyrinthModel(string nom)
        {
            Nom = nom;
        }


    }
}
