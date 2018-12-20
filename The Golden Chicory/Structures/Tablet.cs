using Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class Tablet : Structure
    {
        public int floorLocation;
        public Tablet()
        {
            name = "Tablet";
            description = "Hmm this is a tablet";
            symbol = "¯";
            isInteractible = true;
            interactions.Add(new SignIn(this));
        }
    }
}
