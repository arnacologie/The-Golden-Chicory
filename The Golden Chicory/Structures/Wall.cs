using The_Golden_Chicory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class Wall : Structure
    {
        public Wall()
        {
            this.name = "Wall";
            this.description = "Hmm, this is a wall";
            this.symbol = "■";
        }
    }
}
