using Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory.Interactions;

namespace Structures
{
    public class Stairs : Structure
    {
        public int floorLocation;
        public Stairs(int floorLocation):base()
        {
            name = "Stairs";
            description = "Hmm this is some stairs";
            symbol = "≡";
            isInteractible = true;
            this.floorLocation = floorLocation;
            switch (floorLocation)
            {
                case 1:
                    interactions.Add(new MoveTo4thFloor(this));
                    break;
                default:
                    break;
            }
        }
    }
}
