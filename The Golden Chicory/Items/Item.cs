using The_Golden_Chicory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    public abstract class Item : Entity
    {
        public abstract void pickUp();
    }
}
