
using Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    //TODO Finir Door
    class Door : Structure
    {
        bool isLocked;

        public Door(bool isLocked) : base()
        {
            name = "Door";
            description = "Hmm, this is a door";
            symbol = "|";
            this.isLocked = isLocked;
            interactions.Add(new Open(this));
        }
    }
}
