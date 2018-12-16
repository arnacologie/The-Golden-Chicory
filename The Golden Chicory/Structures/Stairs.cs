using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class Stairs : Structure
    {
        public Stairs():base()
        {
            this.name = "Stairs";
            this.description = "Hmm this is some stairs";
            this.symbol = "S";
        }
    }
}
