using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using static Quests.QuestManager;

namespace Quests
{
    public class Quest
    {
        public string name;
        private Dictionary<EventProgressType, int> taskToComplete;
        public Dictionary<EventProgressType, int> stepsRemaningList;
        private bool isEnabled;
        private int status;
        public readonly int PENDING = 0;
        public readonly int IN_PROGRESS = 1;
        public readonly int COMPLETED = 2;

        public Quest(string name, EventProgressType eventProgressType, int howMuch)
        {
            this.name = name;
            taskToComplete = new Dictionary<EventProgressType, int>();
            taskToComplete.Add(eventProgressType, howMuch);
            stepsRemaningList = new Dictionary<EventProgressType, int>();
            stepsRemaningList.Add(eventProgressType, 0);
            status = PENDING;
            isEnabled = false;
        }

        public void addTask(EventProgressType eventProgressType, int howMuch)
        {
            taskToComplete.Add(eventProgressType, howMuch);
            stepsRemaningList.Add(eventProgressType, 0);
        }

        public void notify(EventProgressType eventProgressType)
        {
            if (isEnabled)
            {
                if (taskToComplete.ContainsKey(eventProgressType))
                {
                    stepsRemaningList[eventProgressType]++;
                    if (checkIfQuestCompleted())
                    {
                        Stage.questOutput.Add("[Quest]" + name + "[COMPLETED]");
                        return;
                    }
                    Stage.questOutput.Add("[Quest]" + name + "[IN PROGRESS)]");
                }
            }
        }

        private bool checkIfQuestCompleted()
        {
            int count = 0;
            foreach (KeyValuePair<EventProgressType, int> item in taskToComplete)
            {
                if (taskToComplete[item.Key] == stepsRemaningList[item.Key])
                {
                    count++;
                }
            }
            if (count == taskToComplete.Keys.Count)
            {
                status = COMPLETED;
                isEnabled = false;
                return true;
            }
            return false;
        }

        public int getStatus()
        {
            return status;
        }

        public void activateQuest()
        {
            Stage.questOutput.Add("[New Quest !]"+name);
            isEnabled = true;
            status = IN_PROGRESS;
        }

        public Dictionary<EventProgressType, int> getTasksToComplete()
        {
            return taskToComplete;
        }
    }
}
