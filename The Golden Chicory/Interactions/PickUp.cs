using Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factories.StructureFactory;

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
            Inventory.getInstance().addItem(interactible);
            Stage.getInstance().MATRIX[interactible.x, interactible.y].onThis = Stage.getInstance().structureFactory.createStructure(StructureType.Floor);
            Stage.interactionTriggeredOutput.Add(interactible.name + " picked up!");
        }

    }
}
