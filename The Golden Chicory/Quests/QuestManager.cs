using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

//Singleton
namespace Quests
{
    public class QuestManager
    {
        private static QuestManager instance;
        public List<Quest> quests { get; set; }
        public enum EventProgressType { EnemyKilled, ItemGivenToNPC, NPCTalked, ThirdFloorReached, LocationReached, MachineTriggered, StudentCardPickedUp, CampusDoorwayOpened}
        public static readonly int QUEST1 = 0;
        public static readonly int QUEST2 = 1;
        private QuestManager()
        {
            quests = new List<Quest>();
            Quest quest1 = new Quest("Find your student card to enter in the campus !", EventProgressType.StudentCardPickedUp, 1);
            quest1.addTask(EventProgressType.CampusDoorwayOpened, 1);
            Quest quest2 = new Quest("You're almost late ! Go to the 3rd Floor whatever it takes !", EventProgressType.ThirdFloorReached, 1);
            quests.Add(quest1);
            quests.Add(quest2);
        }

        public static QuestManager getInstance()
        {
            if(instance == null)
            {
                instance = new QuestManager();
            }
            return instance;
        } 

        public void notify(EventProgressType eventProgressType)
        {
            notifyQuests(eventProgressType);
        }

        private void notifyQuests(EventProgressType eventProgressType)
        {
            foreach (Quest quest in quests)
            {
                quest.notify(eventProgressType);
            }
        }
    }
}
