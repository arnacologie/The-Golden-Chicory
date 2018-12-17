using The_Golden_Chicory;

namespace Interactions
{
    //Decorator
    public abstract class Interaction 
    {
        private Entity interactible;
        private Entity interactor;

        public Interaction(Entity interactible)
        {
            this.interactible = interactible;
        }
        public virtual void trigger(Entity interactor)
        {
            if (!interactible.isInteractible)
            {
                Stage.debugOutput.Add("I can't do this");
                return;
            }
        }
    }
}