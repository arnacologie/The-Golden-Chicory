using Items;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Golden_Chicory
{
    public class Registrator
    {
        public static void doorInKey(Door door, Key key)
        {
            key.registerObserver(door);
        }
    }
}
