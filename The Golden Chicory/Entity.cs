using Interactions;
using System.Collections.Generic;

namespace The_Golden_Chicory
{
    public abstract class Entity
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string description { get; set; }
        public string symbol { get; set; }
        public bool isInteractible { get; set; }
        public List<Interaction> interaction { get; set; }

        public bool interact(int index)
        {
            if (isInteractible)
            {
                interaction[index].trigger();
                return true;
            }
            else return false;
        }
    }
}