using Characters;
using Student_Ennemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using static Characters.Character;

namespace Skills
{
    public class Skill
    {
        public static string GarbageDevLanguageName = "Garbage Dev Language";
        public string name;
        public string description;
        public double damage;
        public SkillType skillType;
        public Entity user;

        public enum SkillType {Natural, LanguageDev, ITKnowledge, Communication}

        public Skill(string name, string description, double damage, SkillType skillType, Entity user)
        {
            this.name = name;
            this.description = description;
            this.damage = damage;
            this.skillType = skillType;
            this.user = user;
        }

        public void useSkill(Character target)
        {
            if (name == GarbageDevLanguageName && target.GetType() == typeof(DevStudent) && target.behavior == Behavior.Aggressive)
            {
                target.takeDamage(0);
                Stage.inCombatOuput.Add(string.Format("{0} use {1} on {2}", user.name, name, target.name));
                Stage.inCombatOuput.Add(string.Format("{0} takes 0 damage ! [{1}/{2}]", target.name, target.health, target.totalHealth));
                Stage.getInstance().showMATRIX();
                Stage.printInCombatOutput();
            }
            else if (target.behavior == Behavior.Aggressive)
            {
                target.takeDamage(damage);
                Stage.inCombatOuput.Add(string.Format("{0} use {1} on {2}", user.name, name, target.name));
                Stage.inCombatOuput.Add(string.Format("{0} takes {1} damage ! [{2}/{3}]", target.name, damage, target.health, target.totalHealth));
                Stage.getInstance().showMATRIX();
                Stage.printInCombatOutput();
            }
        }
    }
}
