using The_Golden_Chicory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class MovedEvent : EventArgs
    {
        public int x { get; set; }
        public int y { get; set; }

        public MovedEvent(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
