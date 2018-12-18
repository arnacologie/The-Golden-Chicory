using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    public abstract class Consumable : Item
    {
        protected List<Observer> observers;

        public Consumable()
        {
            observers = new List<Observer>();
        }
            
    }
}
