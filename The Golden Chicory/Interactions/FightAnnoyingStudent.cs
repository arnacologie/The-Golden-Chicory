using Characters;
using Student_Ennemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Interactions
{
    public class FightAnnoyingStudent : Interaction
    {
        public FightAnnoyingStudent(Entity interactible) : base(interactible)
        {
            name = "Ask to move";
        }

        public override void nonInteratibleOuput()
        {
            Stage.debugOutput.Add("Nothing happened...");
        }

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
            Stage.interactionTriggeredOutput.Add("An "+interactible.name+" is blocking the way to the 4th floor!");
            Stage.interactionTriggeredOutput.Add("He won't move ! It's time to fight !");
            Stage.interactionTriggeredOutput.Add("Press Enter to enter in COMBAT");
            Stage.getInstance().showMATRIX();
            Stage.printInteractionTriggered();
            Console.ReadLine();
            if (interactible.GetType() == typeof(AnnoyingStudent))
            {
                Stage.currentEnemy = (StudentEnemy)interactible;
                Stage.inCombat = true;
            }
        }
    }
}
