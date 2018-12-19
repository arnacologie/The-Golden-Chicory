using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Interactions
{
    public class FightAnnoyingStudent : Interaction
    {
        public FightAnnoyingStudent(Entity interactible) : base(interactible)
        {
            name = "Ask to move";
        }

        public override void nonInteratibleOuput()
        {
            throw new NotImplementedException();
        }

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
            Stage.interactionTriggeredOutput.Add("An "+interactible.name+" is blocking the to the 4th floor!");
            Stage.interactionTriggeredOutput.Add("He won't move ! It's time to fight !");
            Stage.inCombat = true;
        }
    }
}
