using Interfaces;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using The_Golden_Chicory.Events;

namespace Interactions
{
    public class OpenClose : Interaction, Subject
    {

        public OpenClose(Entity interactible) : base(interactible){}

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("It won't move");
        }

        public void notifyObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update(false);
            }
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            observers.Remove(o);
        }

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
            if (interactible.GetType() == typeof(Door) && interactible.isInteractible) {
                Door door = (Door)interactible;
                if (door.isLocked) Stage.interactionTriggeredOutput.Add("This door is locked.");

                else if (!door.isOpen)
                {
                    Stage.interactionTriggeredOutput.Add("You have opened the door");
                    door.isOpen = true;
                    notifyObservers();
                }
                else if (door.isOpen)
                {
                    Stage.interactionTriggeredOutput.Add("You have closed the door");
                    door.isOpen = false;
                    notifyObservers();
                }
            }
            //TODO manage the others entites that may be opened
        }



    }
}
