using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Interactions
{
    public class MoveTo4thFloor : Interaction
    {
        public MoveTo4thFloor(Entity interactible) : base(interactible) {}

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("I can't go to the 4th floor for now.");
        }

        public override void trigger(Entity interactor)
        {
            //Stage.interactionTriggeredOutput.Add("Press Enter to enter use the stairs");
            Stage.getInstance().initMATRIXToSpawnNewLevel();
            Spawner.spawnForthFloor();
            Stage.currentLevel = 4;
        }
    }
}
