using Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using static Skills.Skill;

namespace Characters
{
    //public enum Behavior { Pacific, Neutral, Aggressive };
    //public double health { get; set; }
    //public Behavior behavior;
    public abstract class StudentEnemy : Character
    {
        public bool isDroppingLoot;

        public StudentEnemy(int x, int y, string name, double health, bool isDroppingLoot)
        {
            this.x = x;
            this.y = y;
            this.name = name;
            behavior = Behavior.Aggressive;
            this.health = health;
            totalHealth = health;
            skills = new List<Skill>();
            isAlive = true;
            this.isDroppingLoot = isDroppingLoot;
        }

        public abstract void attack(Character target);

        public abstract void dropLoot();
    }
}
