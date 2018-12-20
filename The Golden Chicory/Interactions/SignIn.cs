using Characters;
using Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using static Quests.QuestManager;

namespace Interactions
{
    public class SignIn : Interaction
    {
        public SignIn(Entity interactible) : base(interactible)
        {

        }

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("You already signed !");
        }

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
            if (interactible.isInteractible)
            {
                Stage.interactionTriggeredOutput.Add("You sign in !");
                QuestManager.getInstance().notify(EventProgressType.TabletSign);
                interactible.isInteractible = false;
                //TODO ugly spawn npc use Factory instead
                Spawner.spawnEntity(6, 4, new NPC("to Abdel", "Hey ! You forgot your laptop yesterday, are you out of your mind ?!\nHere, take it", "Wait! Can you buy me a Kander Boono in the 3rd floor ?\nBuy also something for you with the remaining money !"));
            }
        }
    }
}
