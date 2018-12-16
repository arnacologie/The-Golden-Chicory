using The_Golden_Chicory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactions;

namespace Structures
{
    class Wall : Structure
    {
        public Wall():base()
        {
            name = "Wall";
            description = "Hmm, this is a wall";
            symbol = "■";
            isInteractible = true;
            interactions = new List<Interaction>();
            interactions.Add(new Information(this));
        }
    }
}
