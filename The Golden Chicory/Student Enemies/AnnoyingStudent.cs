using Characters;
using Interactions;
using Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using static Factories.ItemFactory;
using static Factories.StructureFactory;
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
            isInteractible = true;
        }

        public override void attack(Character target)
        {
            skills[0].useSkill(target);
        }

        public override void dropLoot()
        {
            Stage.getInstance().MATRIX[x, y].onThis = Stage.getInstance().structureFactory.createStructure(StructureType.Floor);
            Spawner.spawnEntity(x, y, Stage.getInstance().itemFactory.createItem(ItemType.Bag));
        }
    }
}
