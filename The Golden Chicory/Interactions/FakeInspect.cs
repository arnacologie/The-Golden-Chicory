using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using static Factories.ItemFactory;

namespace Interactions
{
    public class FakeInspect : Interaction
    {
        public FakeInspect(Entity interactible) : base(interactible)
        {
            name = "Inspect Dorm";
        }

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("...");
        }

        public override void trigger(Entity interactor)
        {
            if (!Spawner.alreadySpawnOnce)
            {
                Spawner.spawnEntity(4, 3, Stage.getInstance().itemFactory.createItem(ItemType.StudentCard));
                Stage.interactionTriggeredOutput.Add("Something got ejected from the dorm door when you touched it");
                Spawner.alreadySpawnOnce = true;
            }else Stage.interactionTriggeredOutput.Add("Don't expect another card to be ejected");
        }
    }
}
