using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Golden_Chicory
{
    class NullEntity : Entity
    {
        public NullEntity():base()
        {
            this.name = this.GetType().Name;
            this.description = "This is a "+this.GetType().Name; 
        }
    }
}
