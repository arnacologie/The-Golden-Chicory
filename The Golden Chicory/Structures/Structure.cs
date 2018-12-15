using Interactions;
using The_Golden_Chicory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public abstract class Structure : Entity
    {
        public bool isInteractible { get; set; }
        public Interaction interaction { get; set; }

        public bool interact()
        {
            if (isInteractible)
            {
                interaction.trigger();
                return true;
            }
            else return false;
        }
    }
}
