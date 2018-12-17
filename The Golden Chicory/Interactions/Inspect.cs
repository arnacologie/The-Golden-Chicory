using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Interactions
{
    class Inspect : Interaction
    {
        public Inspect(Entity interactible) : base(interactible) { }

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("...");
        }

        public override void trigger(Entity interactor)
        {
            Stage.interactionTriggeredOutput.Add(interactible.description);
        }
    }
}
