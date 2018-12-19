using Characters;
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
            if (target.behavior == Behavior.Aggressive) {
                target.takeDamage(damage);
            }
        }
    }
}
