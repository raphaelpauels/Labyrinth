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
            Vue.Affiche(Model);
        }
    }
}
