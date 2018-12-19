﻿using Characters;
using Interactions;
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
        public AnnoyingStudent(int x, int y, string name, double health, bool isDroppingLoot) : base(x, y, name, health, isDroppingLoot)
        {
            description = "This is a " + name;
            skills.Add(new Skill("Headbutt", name + " use Headbutt", 1, SkillType.Natural));
            symbol = "ß";
            interactions.Add(new FightAnnoyingStudent(this));
        }

        public override void attack(Character target)
        {
            skills[0].useSkill(target);
        }
    }
}
