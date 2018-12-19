using Interactions;
using Interfaces;
using Items;
using Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using The_Golden_Chicory.Interactions;
using static Quests.QuestManager;

namespace Items
{
    public class Key : Consumable, Subject
    {
        public static string studentCardName = "Student Card";
        //Ƒ
        public Key(string name):base()
        {
            this.name = name;
            description = "This is a "+name;
            symbol = "▀";
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
