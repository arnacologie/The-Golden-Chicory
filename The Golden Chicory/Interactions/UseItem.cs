using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Interactions
{
    public class UseItem : Interaction
    {
        public UseItem(Entity interactible) : base(interactible) { }

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("I can't use this item");
        }

        public override void trigger(Entity interactor)
        {
            if(interactible.GetType() == typeof(Key))
            {
                Key key = (Key)interactible;
                key.notifyObservers();
            }
            Stage.interactionTriggeredOutput.Add(interactible.description);
        }
    }
}
