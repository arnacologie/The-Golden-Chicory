﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Interactions
{
    public class Open : Interaction
    {
        public Open(Entity interactible) : base(interactible){}

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
        }
    }
}
