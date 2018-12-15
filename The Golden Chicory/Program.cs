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
            bool PlayerTurn = true;
            Stage.getInstance().initConsole();
            Stage.getInstance().initMATRIX();

            Spawner.spawnLevel1();

            Stage.getInstance().showMATRIX();
            Console.WriteLine(Stage.getInstance().MATRIX[0, 0].onThis.name);
            while (PlayerTurn)
            {
                Stage.player.move();
            }
            
        }
    }
}
