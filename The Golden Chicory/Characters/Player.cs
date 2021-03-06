﻿
using Events;
using The_Golden_Chicory;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Factories.StructureFactory;
using Interactions;
using Structures;
using Items;
using Quests;
using static Quests.QuestManager;
using Skills;
using static Skills.Skill;

namespace Characters
{
    public class Player : Character
    {
        public static string namePlayer = "Endive";
        public static string symbolInit { get; set; }
        public string symbolUp { get; set; }
        public string symbolLeft { get; set; }
        public string symbolRight { get; set; }
        public string symbolDown { get; set; }
        public Dictionary<string, int[]> closeCases;
        public Tuple<string, int[]> facingCase;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
            name = namePlayer;
            description = "It's the player";
            symbol = "±";
            symbolInit = "±";
            symbolUp = "↑";
            symbolLeft = "←";
            symbolRight = "→";
            symbolDown = "↓";
            health = 10;
            totalHealth = health;
            isInteractible = true;
            behavior = Behavior.Aggressive;
            isAlive = true;
            skills = new List<Skill>();
            skills.Add(new Skill(Skill.GarbageDevLanguageName, "[All] DMG 2 , [Dev Student] DMG 0", 2, SkillType.Natural, this));
        }

        public bool action()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Z:
                    return move(x, y - 1, symbolUp);
                case ConsoleKey.S:
                    return move(x, y + 1, symbolDown);
                case ConsoleKey.Q:
                    return move(x - 1, y, symbolLeft);
                case ConsoleKey.D:
                    return move(x + 1, y, symbolRight);
                case ConsoleKey.E:
                    return useItemInventory();
                case ConsoleKey.UpArrow:
                    return turn(symbolUp);
                case ConsoleKey.DownArrow:
                    return turn(symbolDown);
                case ConsoleKey.LeftArrow:
                    return turn(symbolLeft);
                case ConsoleKey.RightArrow:
                    return turn(symbolRight);
                case ConsoleKey.D1:
                    return interact(1); ;
                case ConsoleKey.D2:
                    return interact(2);
                case ConsoleKey.D3:
                    return interact(3);
                case ConsoleKey.D4:
                    return interact(4);
                    //TODO Add Tab to showInventory
                default:
                    Stage.getInstance().showMATRIX();
                    //Console.WriteLine("Error WRONG KEY {0} {1} (Z,Q,S,D,↑,←,↓,→,1,2,3,4)", Stage.getFunctionName(), GetType().Name);
                    return false;
            }
        }

        private bool move(int x, int y, string symbolDirection)
        {
            if (checkMovement(x, y))
            {
                //OnPlayerMove(this, new MovedEvent(x, y));
                Case currentCase = Stage.getInstance().MATRIX[this.x, this.y];
                //if currentCase is an opened door
                if (currentCase.onThis.GetType() == typeof(Door))
                {
                    Stage.getInstance().MATRIX[x, y].onThis.onThis = null;
                    Stage.getInstance().MATRIX[x, y].onThis.playerIsOnTop();
                }
                else currentCase.onThis = Stage.getInstance().structureFactory.createStructure(StructureType.Floor);
                Case nextCase = Stage.getInstance().MATRIX[x, y];
                //if nextCase is an opened door
                if (nextCase.onThis.GetType() == typeof(Door))
                {
                    Stage.getInstance().MATRIX[x, y].onThis.onThis = this;
                    Stage.getInstance().MATRIX[x, y].onThis.playerIsOnTop();
                }
                //TODO nextcase == Stage.getInstance().MATRIX[x, y] ?
                else nextCase.onThis = this;
                
                this.x = x;
                this.y = y;
                symbol = symbolDirection;
                Stage.getInstance().showMATRIX();
                //Console.WriteLine("{0} {1} called, SUCCESS {2}{3}", Stage.getFunctionName(), GetType().Name, x, y);
                scanForInteraction();
                return true;
            }
            else
            {
                symbol = symbolDirection;
                Stage.getInstance().showMATRIX();
                //if(x >= 0 && x < Stage.MATRIX_SIZE && y >= 0 && y < Stage.MATRIX_SIZE)
                //    Console.WriteLine("{0} {1} called, FAIL (Collision avec {2})", Stage.getFunctionName(), GetType().Name, Stage.getInstance().MATRIX[x, y].onThis.name);
                //else Console.WriteLine("{0} {1} called, FAIL (It's the void down here!)", Stage.getFunctionName(), GetType().Name, checkMovement(x, y));
                initFacingCase();
                return false;
            }
        }

        private bool checkMovement(int x, int y)
        {
            if (Validator.isCaseValidForMovement(x, y))
            {
                return true;
            }
            return false;
        }

        private bool turn(string symbolDirection)
        {
            symbol = symbolDirection;
            Stage.getInstance().showMATRIX();
            //Console.WriteLine("{0} {1} called, SUCCESS", Stage.getFunctionName(), this.GetType().Name);
            initFacingCase();
            return true;
        }

        private bool interact(int touchNumber)
        {

            if (facingCase != null && touchNumber > 0 && touchNumber <= 
                Stage.getInstance().MATRIX[facingCase.Item2[0],facingCase.Item2[1]].onThis.interactions.Count)
            {
                switch (touchNumber)
                {
                    case 1:
                        //TODO finir 
                        Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.interactions[0].trigger(this);
                        Stage.getInstance().showMATRIX();
                        //Console.WriteLine("{0} {1} called, SUCCESS", Stage.getFunctionName(), this.GetType().Name);
                        return true;
                    case 2:
                        Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.interactions[1].trigger(this);
                        Stage.getInstance().showMATRIX();
                        //Console.WriteLine("{0} {1} called, SUCCESS", Stage.getFunctionName(), this.GetType().Name);
                        return true;
                    case 3:
                        Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.interactions[2].trigger(this);
                        Stage.getInstance().showMATRIX();
                        //Console.WriteLine("{0} {1} called, SUCCESS", Stage.getFunctionName(), this.GetType().Name);
                        return true;
                    case 4:
                        Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.interactions[3].trigger(this);
                        Stage.getInstance().showMATRIX();
                        //Console.WriteLine("{0} {1} called, SUCCESS", Stage.getFunctionName(), this.GetType().Name);
                        return true;
                    default:
                        //Stage.debugOutput.Add(string.Format("Erreur WRONG KEY (1-4) {0} {1}", Stage.getFunctionName(), GetType().Name));
                        Stage.getInstance().showMATRIX();
                        return false;
                }
            }
            Stage.getInstance().showMATRIX();
            return false;
        }

        public bool scanForInteraction()
        {
            initCloseCases();
            initFacingCase();
            return true;
        }

        public void initCloseCases()
        {
            closeCases = new Dictionary<string, int[]>();
            int xCloseCase;
            int yCloseCase;

            xCloseCase = x - 1;
            yCloseCase = y;
            addValidCloseCase(symbolLeft, xCloseCase, yCloseCase, new int[2]);
            xCloseCase = x + 1;
            addValidCloseCase(symbolRight, xCloseCase, yCloseCase, new int[2]);
            xCloseCase = x;
            yCloseCase = y - 1;
            addValidCloseCase(symbolUp, xCloseCase, yCloseCase, new int[2]);
            yCloseCase = y + 1;
            addValidCloseCase(symbolDown, xCloseCase, yCloseCase, new int[2]);
        }

        private bool addValidCloseCase(string symbolDirection, int xCloseCase, int yCloseCase, int[] closeCaseCoordinates)
        {
            if (Validator.isCaseValid(xCloseCase, yCloseCase))
            {
                closeCaseCoordinates[0] = xCloseCase;
                closeCaseCoordinates[1] = yCloseCase;
                closeCases.Add(symbolDirection, closeCaseCoordinates);
                return true;
            }
            return false;
        }

        private void getCloseCases()
        {
            foreach (KeyValuePair<string, int[]> item in closeCases)
            {
                Stage.closeInteractionsOutput.Add(string.Format("Direction {0} = {1}({2},{3})", item.Key, Stage.getInstance().MATRIX[item.Value[0],
                    item.Value[1]].onThis.name, item.Value[0], item.Value[1]));
            }
        }

        private void initFacingCase()
        {
            facingCase = null;
            foreach (KeyValuePair<string, int[]> item in closeCases)
            {
                if (item.Key.Equals(symbol)) facingCase = new Tuple<string, int[]>(item.Key, item.Value);
            }
            if (facingCase != null)
            {
                //Stage.facingInteractionOutput.Add(string.Format("Direction {0} = {1}({2},{3})", facingCase.Item1,
                //    Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.name, facingCase.Item2[0], facingCase.Item2[1]));
                foreach (Interaction interaction in Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.interactions)
                {
                    Stage.facingInteractionOutput.Add(string.Format("{0} {1} [{2}]", interaction.name,Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.name, Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.interactions.IndexOf(interaction) + 1));
                }
                
            }
        }

        private bool useItemInventory()
        {
            interactWithInventory();
            Stage.getInstance().showMATRIX();
            return false;
        }

        //TODO move this function to inventory
        private bool interactWithInventory()
        {
            if (Inventory.getInstance().getItems().Count > 0)
            {
                if (facingCase != null)
                {
                    if (Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.GetType() == typeof(Door) &&
                        Inventory.getInstance().getItems().OfType<Key>().Any())
                    {
                        Door door = (Door)Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis;
                        if (door.isLocked)
                        {
                            door.isLocked = false;
                            if(door.name.Equals(Door.campusDoorName))
                            {
                                Stage.interactionTriggeredOutput.Add("You can now open the "+door.name);
                                QuestManager.getInstance().notify(EventProgressType.CampusDoorwayOpened);
                            }

                            else Stage.interactionTriggeredOutput.Add("I unlocked the door with the " + door.name);
                        }
                        else
                            Stage.interactionTriggeredOutput.Add("The door is unlocked");
                    }
                    else
                        Stage.interactionTriggeredOutput.Add("I don't have the appropriate item");
                }
                else
                    Stage.interactionTriggeredOutput.Add("I need something interactible in front of me to use my item");
            }
            else
                Stage.interactionTriggeredOutput.Add("My inventory is empty");
            return false;
        }

        public bool combatAction()
        {
            Stage.availableCombatOptionsOutput.Add("Fight [1]");
            Stage.availableCombatOptionsOutput.Add("Use Item [2]");
            Stage.getInstance().showMATRIX();
            Stage.printAvailableCombatOptionsOutput();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    return fightOptions();
                case ConsoleKey.D2:
                    return itemOptions();
                default:
                    Stage.getInstance().showMATRIX();
                    Console.WriteLine("Error WRONG KEY {0} {1} (1,2)", Stage.getFunctionName(), GetType().Name);
                    return false;
            }
        }

        public bool fightOptions()
        {
            Stage.availableCombatOptionsOutput.Add("Show attack(s) [1]");
            Stage.availableCombatOptionsOutput.Add("Show skills(s) [2]");
            Stage.availableCombatOptionsOutput.Add("Go back [BACKSPACE]");
            Stage.getInstance().showMATRIX();
            Stage.printAvailableCombatOptionsOutput();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    return getAvailableAttackOptions();
                case ConsoleKey.D2:
                    return getAvailableSkillOptions();
                case ConsoleKey.Backspace:
                    return combatAction();
                default:
                    Stage.getInstance().showMATRIX();
                    //Console.WriteLine("Error WRONG KEY {0} {1} (1,2)", Stage.getFunctionName(), GetType().Name);
                    fightOptions();
                    return true;
            }
        }

        public bool getAvailableAttackOptions()
        {
            //checkSkillOption(int value)
            foreach (Skill skill in skills)
            {
                if (skill.skillType == SkillType.Natural)
                    Stage.availableCombatOptionsOutput.Add(string.Format("{0} : {1} [{2}]", skill.name, skill.description, skills.IndexOf(skill) + 1));
            }
            Stage.availableCombatOptionsOutput.Add("Go back [BACKSPACE]");
            Stage.getInstance().showMATRIX();
            Stage.printAvailableCombatOptionsOutput();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    if (checkAttackOption(1))
                    {
                        skills[0].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableAttackOptions();
                    return true;
                case ConsoleKey.D2:
                    if (checkAttackOption(2))
                    {
                        skills[1].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableAttackOptions();
                    return true;
                case ConsoleKey.D3:
                    if (checkAttackOption(3))
                    {
                        skills[2].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableAttackOptions();
                    return true;
                case ConsoleKey.D4:
                    if (checkAttackOption(4))
                    {
                        skills[3].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableAttackOptions();
                    return true;
                case ConsoleKey.D5:
                    if (checkAttackOption(5))
                    {
                        skills[4].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableAttackOptions();
                    return true;
                case ConsoleKey.D6:
                    if (checkAttackOption(6))
                    {
                        skills[5].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableAttackOptions();
                    return true;
                case ConsoleKey.Backspace:
                    return fightOptions();
                default:
                    Stage.getInstance().showMATRIX();
                    //Console.WriteLine("Error WRONG KEY {0} {1} (1,2)", Stage.getFunctionName(), GetType().Name);
                    getAvailableAttackOptions();
                    return true;
            }
        }

        public bool getAvailableSkillOptions()
        {
            bool skillFound = false;
            foreach (Skill skill in skills)
            {
                if (skill.skillType != SkillType.Natural)
                {
                    Stage.availableCombatOptionsOutput.Add(string.Format("{0} : {1} [{2}]", skill.name, skill.description, skills.IndexOf(skill) + 1));
                    skillFound = true;
                }
            }
            if(!skillFound) Stage.availableCombatOptionsOutput.Add("You haven't learn a skill yet");
            Stage.availableCombatOptionsOutput.Add("Go back [BACKSPACE]");
            Stage.getInstance().showMATRIX();
            Stage.printAvailableCombatOptionsOutput();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    if (checkSkillOption(1))
                    {
                        skills[0].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableSkillOptions();
                    return true;
                case ConsoleKey.D2:
                    if (checkSkillOption(2))
                    {
                        skills[1].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableSkillOptions();
                    return true;
                case ConsoleKey.D3:
                    if (checkSkillOption(3))
                    {
                        skills[2].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableSkillOptions();
                    return true;
                case ConsoleKey.D4:
                    if (checkSkillOption(4))
                    {
                        skills[3].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableSkillOptions();
                    return true;
                case ConsoleKey.D5:
                    if (checkSkillOption(5))
                    {
                        skills[4].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableSkillOptions();
                    return true;
                case ConsoleKey.D6:
                    if (checkSkillOption(6))
                    {
                        skills[5].useSkill(Stage.currentEnemy);
                        return true;
                    }
                    getAvailableSkillOptions();
                    return true;
                case ConsoleKey.Backspace:
                    return fightOptions();
                default:
                    Stage.getInstance().showMATRIX();
                    //Console.WriteLine("Error WRONG KEY {0} {1} (1,2)", Stage.getFunctionName(), GetType().Name);
                    getAvailableSkillOptions();
                    return true;
            }
        }

        private bool checkSkillOption(int value)
        {
            int count = 0;
            foreach (Skill skill in skills)
            {
                if (skill.skillType != SkillType.Natural)
                    continue;
                count++;
            }
            return value <= count;
        }

        private bool checkAttackOption(int value)
        {
            int count = 0;
            foreach (Skill skill in skills)
            {
                if (skill.skillType == SkillType.Natural)
                    count++;
            }
            return value <= count;
        }

        public bool itemOptions()
        {
            Stage.getInstance().showMATRIX();
            Console.WriteLine("You don't have any consumable items\nGo back [BACKSPACE]");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Backspace:
                    combatAction();
                    return true;
                default:
                    Stage.getInstance().showMATRIX();
                    itemOptions();
                    return true;
            }
            
        }

        public void learnNewSkill(Skill skill)
        {
            skills.Add(skill);
        }
    }
}
