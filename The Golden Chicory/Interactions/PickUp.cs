using Interactions;
using Items;
using Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factories.StructureFactory;
using static Quests.QuestManager;

namespace The_Golden_Chicory.Interactions
{
    public class PickUp : Interaction
    {
        public PickUp(Entity interactible) : base(interactible)
        {
        }

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("I can't pick up this");
        }

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
            if (interactible.GetType() == typeof(Bag))
            {
                Bag bag = (Bag)interactible;
                Stage.player.learnNewSkill(bag.skill);
                Stage.interactionTriggeredOutput.Add("New Attack learned ! -> "+bag.skill.name);
            }
            else if (interactible.GetType() == typeof(Key) && interactible.name.Equals(Key.studentCardName))
            {
                    QuestManager.getInstance().notify(EventProgressType.StudentCardPickedUp);
            }
            Inventory.getInstance().addItem(interactible);
            Stage.getInstance().MATRIX[interactible.x, interactible.y].onThis = Stage.getInstance().structureFactory.createStructure(StructureType.Floor);
            Stage.interactionTriggeredOutput.Add(interactible.name + " picked up!");
        }

    }
}
