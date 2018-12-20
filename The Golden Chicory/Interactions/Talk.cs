using Characters;
using Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Interactions
{
    public class Talk : Interaction
    {
        public Talk(Entity interactible) : base(interactible)
        {

        }

        public override void nonInteratibleOuput()
        {
            Stage.interactionTriggeredOutput.Add("...");
        }

        public override void trigger(Entity interactor)
        {
            base.trigger(interactor);
            if (interactible.GetType() == typeof(NPC))
            {
                NPC npc = (NPC)interactible;
                Stage.getInstance().showMATRIX();
                Stage.interactionTriggeredOutput.Add(npc.dialog1+"\nPress Enter to continue the conversation");
                Stage.printInteractionTriggered();
                Console.ReadLine();
                Stage.interactionTriggeredOutput.Add(npc.dialog2);
                if(npc.name.Equals(NPC.Abdel))
                    QuestManager.getInstance().quests[QuestManager.QUEST4].activateQuest();
            }

        }
    }
}
