using The_Golden_Chicory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public abstract class Character : Entity
    {
        public enum Behavior {Pacific, Aggressive};
        public double health { get; set; }
        public Behavior behavior;
        public bool isAlive;

        public void takeDamage(double damage)
        {
            health -= damage;
        }
    }
}
