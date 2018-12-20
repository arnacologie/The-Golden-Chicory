using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skills;
using The_Golden_Chicory;
using The_Golden_Chicory.Interactions;
using static Skills.Skill;

namespace Items
{
    public class Bag : Weapon
    {
        public static bool alreadySpawn = false;
        public Bag()
        {
            name = "Your bag";
            description = "This is your bag";
            isInteractible = true;
            symbol = "§";
            interactions.Add(new PickUp(this));
            skill = new Skill("Big bag", "[All] DMG 3", 3, SkillType.Natural, Stage.player);
        }

    }
}
