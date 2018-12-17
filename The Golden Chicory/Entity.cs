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
        public List<Interaction> interactions { get; set; }
        public Entity onThis { get; set; }

        public Entity()
        {
            interactions = new List<Interaction>();
        }

        public virtual void playerIsOnTop() { }
    }
}