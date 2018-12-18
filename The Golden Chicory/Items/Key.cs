using Interactions;
using Interfaces;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using The_Golden_Chicory.Interactions;

namespace Items
{
    public class Key : Consumable, Subject
    {

        public Key(string name):base()
        {
            this.name = name;
            description = "This is a "+name;
            symbol = "Ƒ";
            isInteractible = true;
            interactions = new List<Interaction>();
            interactions.Add(new PickUp(this));
        }

        public void notifyObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update(true);
            }
        }

        public override void pickUp()
        {
            Inventory.getInstance().addItem(this);
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            observers.Remove(o);
        }
    }
}
