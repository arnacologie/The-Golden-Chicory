using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factories.StructureFactory;

namespace The_Golden_Chicory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stage.inCombat = false;
            Stage.getInstance().initConsole();
            Stage.getInstance().initMATRIX();

            Spawner.spawnFirstFloor();
            //Spawner.spawnOutside();

            Stage.getInstance().showMATRIX();
            Console.WriteLine(Stage.getInstance().MATRIX[0, 0].onThis.name);
            Stage.printDebug();
            Stage.printCloseInteractions();
            while (true)
            {
                while (!Stage.inCombat)
                {
                    //Stage.player.scanForInteraction();
                    Stage.printQuestOuput();
                    Stage.player.action();
                    Stage.printDebug();
                    Stage.printFacingInteractions();
                    Stage.printInteractionTriggered();
                }
                while (Stage.inCombat)
                {
                    Stage.printDebug();
                    Stage.printQuestOuput();
                    Stage.player.combatAction();
                    Stage.currentEnemy.attack(Stage.player);
                    Stage.printInCombatOutput();
                    Stage.checkDeath();
                }
                Stage.printInCombatOutput();
            }
            
        }
    }
}
