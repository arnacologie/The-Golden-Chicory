using The_Golden_Chicory;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class Case
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool isWalkable { get; set; }
        public Entity onThis { get; set; }

        public Case(int x, int y)
        {
            this.x = x;
            this.y = y;
            isWalkable = true;
            onThis = new Floor();
        }

        public string getEntitySymbol()
        {
            return onThis.symbol;
        }
    }
}
