using Interfaces;
using System.Collections.Generic;
using The_Golden_Chicory;

namespace Interactions
{
    //Decorator
    public abstract class Interaction
    {
        protected Entity interactible;
        protected Entity interactor;
        protected List<Observer> observers;
        public string name;

        public Interaction(Entity interactible)
        {
            this.interactible = interactible;
            name = GetType().Name;
            observers = new List<Observer>();
        }
        public virtual void trigger(Entity interactor)
        {
            this.interactor = interactor;
            if (!interactible.isInteractible)
            {
                nonInteratibleOuput();
                return;
            }
        }

        public abstract void nonInteratibleOuput();
    }
}