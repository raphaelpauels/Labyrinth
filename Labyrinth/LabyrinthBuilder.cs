using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class LabyrinthBuilder : IEnumerable<KeyValuePair<PositionLabyrinth, IElementLabyrinth>>
    {
        public Dictionary<PositionLabyrinth, IElementLabyrinth> grille;
        public LabyrinthModel this[string name]
        {
            get
            {
                return new LabyrinthModel();
            }
        }

        public IEnumerator<KeyValuePair<PositionLabyrinth, IElementLabyrinth>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
