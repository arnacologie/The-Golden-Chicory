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
        public enum EventProgressType { EnemyKilled, ItemGivenToNPC, NPCTalked, LocationReached, MachineTriggered, StudentCardPickedUp, CampusDoorwayOpened}
        public static readonly int QUEST1 = 0;
        private QuestManager()
        {
            quests = new List<Quest>();
            Quest quest = new Quest("Find your student card to enter in the campus !", EventProgressType.StudentCardPickedUp, 1);
            quest.addTask(EventProgressType.CampusDoorwayOpened, 1);
            quests.Add(quest);
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
