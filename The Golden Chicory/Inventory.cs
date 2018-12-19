using System;
using System.Collections.Generic;
using Items;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactions;

namespace The_Golden_Chicory
{
    public class Inventory : Entity
    {
        private static Inventory instance;
        private List<Entity> items;                     

        private Inventory()
        {
            items = new List<Entity>();
        }

        public static Inventory getInstance()
        {
            if (instance == null) instance = new Inventory();
            return instance;
        }

        public void addItem(Entity item)
        {
            Entity interactible = item.interactions[0].interactible;
            item.interactions.Clear();
            item.interactions.Add(new UseItem(interactible));
            items.Add(item);
        }

        public List<Entity> getItems()
        {
            return items;
        }
    }
}
