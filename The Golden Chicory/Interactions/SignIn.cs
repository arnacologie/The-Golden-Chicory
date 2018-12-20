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
            Stage.interactionTriggeredOutput.Add("I can't sign in for now");
        }

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
            Stage.interactionTriggeredOutput.Add("You sign in !");
            QuestManager.getInstance().notify(EventProgressType.TabletSign);
            //TODO ugly spawn npc
            Spawner.spawnEntity(6, 4, new NPC("Abdel", "Hey ! You forgot your laptop yesterday, how you out of your mind ?!\nHere, take it", "Wait! Can you buy me a Kander Boono in the 3rd floor ?\nYou can buy something for you too, thanks !"));
        }
    }
}
