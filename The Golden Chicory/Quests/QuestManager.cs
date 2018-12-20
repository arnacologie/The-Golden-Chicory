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
        public enum EventProgressType { AnnoyingStudentKilled, BuyBoono, BuySoda, TabletSign, StudentEnemyKilled, ItemGivenToNPC, NPCTalked, ForthFloorReached, LocationReached, MachineTriggered, StudentCardPickedUp, CampusDoorwayOpened}
        public static readonly int QUEST1 = 0;
        public static readonly int QUEST2 = 1;
        public static readonly int QUEST3 = 2;
        public static readonly int QUEST4 = 3;
        private QuestManager()
        {
            quests = new List<Quest>();
            Quest quest1 = new Quest("Find your student card to enter in the campus !", EventProgressType.StudentCardPickedUp, 1);
            quest1.addTask(EventProgressType.CampusDoorwayOpened, 1);
            Quest quest2 = new Quest("You're almost late ! Go to the 4th Floor whatever it takes !", EventProgressType.StudentEnemyKilled, 1);
            quest2.addTask(EventProgressType.ForthFloorReached, 1);
            Quest quest3 = new Quest("Go sign in on the tablet ! ", EventProgressType.TabletSign, 1);
            //TODO finish quest4
            Quest quest4 = new Quest("Buy a Kander Boono for Abdel and a Soda for you!", EventProgressType.BuyBoono, 1);
            quest4.addTask(EventProgressType.BuySoda, 1);
            quests.Add(quest1);
            quests.Add(quest2);
            quests.Add(quest3);
            quests.Add(quest3);
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
