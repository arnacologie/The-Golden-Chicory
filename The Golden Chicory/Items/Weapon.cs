using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    public abstract class Weapon : Item
    {
        public override void pickUp()
        {
            throw new NotImplementedException();
        }
    }
}
