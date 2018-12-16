﻿using Characters;
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
            bool PlayerTurn = true;
            Stage.getInstance().initConsole();
            Stage.getInstance().initMATRIX();

            Spawner.spawnLevel1();

            Stage.getInstance().showMATRIX();
            Console.WriteLine(Stage.getInstance().MATRIX[0, 0].onThis.name);
            Stage.player.printDebug();
            while (PlayerTurn)
            {
                //Stage.player.scanForInteraction();
                Stage.player.moveOrTurn();
                Stage.player.printDebug();

            }
            
        }
    }
}
