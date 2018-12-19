using Characters;
using Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Skills.Skill;

namespace Student_Ennemies
{
    public class AnnoyingStudent : StudentEnemy
    {
        public AnnoyingStudent(string name, double health, bool isDroppingLoot) : base(name, health, isDroppingLoot)
        {
            skills.Add(new Skill("Headbutt", name + " use Headbutt", 1, SkillType.Natural));
        }

        public override void attack(Character target)
        {
            skills[0].useSkill(target);
        }
    }
}
