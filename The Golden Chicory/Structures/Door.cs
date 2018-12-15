
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

        public Door(bool isLocked)
        {
            this.name = "Door";
            this.description = "Hmm, this is a door";
            this.symbol = "D";
            this.isLocked = isLocked;
        }
    }
}
