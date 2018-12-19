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
        public static string GarbageDevLanguageName = "Garbage Language Dev";
        public string name;
        public string description;
        public double damage;
        public SkillType skillType;

        public enum SkillType {Natural, LanguageDev, ITKnowledge, Communication}

        public Skill(string name, string description, double damage, SkillType skillType)
        {
            this.name = name;
            this.description = description;
            this.damage = damage;
            this.skillType = skillType;
        }

        public void useSkill(Character target)
        {
            if (name == GarbageDevLanguageName && target.GetType() == typeof(DevStudent) && target.behavior == Behavior.Aggressive)
            {
                target.takeDamage(0);
            }
            else if (target.behavior == Behavior.Aggressive)
            {
                target.takeDamage(damage);
            }
        }
    }
}
