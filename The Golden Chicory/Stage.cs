﻿using Characters;
using Factories;
using Map;
using Quests;
using Student_Ennemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Factories.StructureFactory;
using static Quests.QuestManager;

namespace The_Golden_Chicory
{
    //Singleton
    public class Stage
    {
        private static Stage instance;
        public static readonly int MATRIX_SIZE = 10;
        public static readonly int MAX_INTERACTION = 4;
        public Case[,] MATRIX { get; set; }
        private CaseFactory caseFactory;
        public StructureFactory structureFactory { get; set; }
        public ItemFactory itemFactory { get; set; }
        public StudentEnemyFactory studentEnemyFactory { get; set; }
        public static Player player { get; set; }
        public static StudentEnemy currentEnemy;
        public static bool inCombat;
        public static int currentLevel;
        public static List<string> debugOutput;
        public static List<string> questOutput;
        public static List<string> closeInteractionsOutput;
        public static List<string> facingInteractionOutput;
        public static List<string> interactionTriggeredOutput;
        public static List<string> inCombatOuput;
        public static List<string> availableCombatOptionsOutput;

        public static string getFunctionName([CallerMemberName] string caller = null)
        {
            return caller;
        }

        private Stage()
        {
            MATRIX = new Case[MATRIX_SIZE, MATRIX_SIZE];
            caseFactory = new CaseFactory();
            structureFactory = new StructureFactory();
            itemFactory = new ItemFactory();
            studentEnemyFactory = new StudentEnemyFactory();
            player = new Player(0, 0);
            debugOutput = new List<string>();
            facingInteractionOutput = new List<string>();
            closeInteractionsOutput = new List<string>();
            interactionTriggeredOutput = new List<string>();
            questOutput = new List<string>();
            inCombatOuput = new List<string>();
            availableCombatOptionsOutput = new List<string>();
            currentLevel = 0;
        }

        public static Stage getInstance()
        {
            if (instance == null)
            {
                instance = new Stage();
            }
            return instance;
        }

        public void initMATRIX()
        {
            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    MATRIX[x, y] = caseFactory.createCase(x, y);
                }
            }
        }

        public void initMATRIXToSpawnNewLevel()
        {
            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    MATRIX[x, y] = caseFactory.recreateCase(x, y);
                }
            }
        }

        public void initConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WindowHeight = 33;
        }

        public void showMATRIX()
        {
            Console.Clear();
            ASCIICasePrinter.printASCIIMap();
        }

        public static void printDebug()
        {
            //Console.WriteLine("Debug:");
            //Console.WriteLine(debugOutput.Count);
            foreach (string debug in debugOutput)
            {
                Console.WriteLine(debug);
            }
            debugOutput.Clear();
        }

        public static void printCloseInteractions()
        {
            //Console.WriteLine("Close Interactions: ");
            foreach (string interactionDetail in closeInteractionsOutput)
            {
                Console.WriteLine(interactionDetail);
            }
            closeInteractionsOutput.Clear();
        }

        public static void printFacingInteractions()
        {
            //Console.WriteLine("Facing interactions: ");
            foreach (string facingInteractionDetail in facingInteractionOutput)
            {
                Console.WriteLine(facingInteractionDetail);
            }
            facingInteractionOutput.Clear();
        }

        public static void printInteractionTriggered()
        {
            //Console.WriteLine("Interaction Triggered: ");
            foreach (string interactionTriggeredDetail in interactionTriggeredOutput)
            {
                Console.WriteLine(interactionTriggeredDetail+"\n");
            }
            interactionTriggeredOutput.Clear();
        }

        public static void printQuestOuput()
        {
            //Console.WriteLine("Quest Ouput: ");
            foreach (string questOutputDetail in questOutput)
            {
                Console.WriteLine(questOutputDetail);
            }
            questOutput.Clear();
        }

        public static void printInCombatOutput()
        {
            foreach (string inCombatOuputDetail in inCombatOuput)
            {
                Console.Write(inCombatOuputDetail+"\n");
            }
            inCombatOuput.Clear();
        }

        public static void printAvailableCombatOptionsOutput()
        {
            foreach (string availableCombatOptionsOutputDetail in availableCombatOptionsOutput)
            {
                Console.Write(availableCombatOptionsOutputDetail+"\n");
            }
            availableCombatOptionsOutput.Clear();
        }

        public static bool checkDeath()
        {
            if(player.health<=0)
            {
                inCombatOuput.Add("Game Over... Re-spawning");
                switch (currentLevel)
                {
                    case 1:
                        Stage.getInstance().initMATRIXToSpawnNewLevel();
                        Console.ReadLine();
                        Spawner.spawnFirstFloor();
                        return false;
                    default:
                        return false;
                }
            }
            else if (currentEnemy.health <= 0)
            {
                currentEnemy.isAlive = false;
                QuestManager.getInstance().notify(EventProgressType.StudentEnemyKilled);
                if (currentEnemy.isDroppingLoot)
                {
                    currentEnemy.dropLoot();
                }
                currentEnemy.isInteractible = false;
                inCombat = false;
                Console.Write(currentEnemy.name+" is dead ! ");
                return true;
            }
            return false;
        }

        public static void waitBetweenTurns(bool nextEnemyTurn)
        {
            if(nextEnemyTurn)
                Console.WriteLine("Press Enter for Enemy Turn");
            else
                Console.WriteLine("Press Enter to fight back !");
            Console.ReadLine();
        }
    }
}
