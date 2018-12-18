using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factories.StructureFactory;
using static Factories.ItemFactory;
using Structures;
using Items;

namespace The_Golden_Chicory
{
    public static class Spawner
    {
        public static bool spawnEntity(int x, int y, Entity entity)
        {
            if (!Validator.isCaseEmpty(x, y))
            {
                Console.WriteLine("{0} n'a pas pu être instancié car la case est déjà occupée par {1}", entity.name, Stage.getInstance().MATRIX[x, y].onThis.name);
                return false;
            }
            else
            {
                entity.x = x;
                entity.y = y;
                Stage.getInstance().MATRIX[x, y].onThis = entity;
                Console.WriteLine("{0} Spawn", entity.name);
                return true;
            }
        }

        public static void spawnLevel1()
        {
            //top row
            for (int x = 0; x < Stage.MATRIX_SIZE; x++)
            {
                spawnEntity(x, 0, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //border lines
            for (int y = 1; y < Stage.MATRIX_SIZE - 1; y++)
            {
                for (int x = 0; x < Stage.MATRIX_SIZE; x = x + Stage.MATRIX_SIZE - 1)
                {
                    spawnEntity(x, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
                }
            }
            //other cases
            for (int x = 4; x < 9; x++)
            { 
                if(x == 5)
                {
                    spawnEntity(x, 4, Stage.getInstance().structureFactory.createStructure(StructureType.DoorLocked));
                    continue;
                }
                spawnEntity(x, 4, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            for (int y = 5; y < 9; y++)
            {
                spawnEntity(4, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            spawnEntity(2, 8, Stage.getInstance().itemFactory.createItem(ItemType.SimpleKey));
            //register door in key
            Registrator.doorInKey((Door)Stage.getInstance().MATRIX[5, 4].onThis, (Key)Stage.getInstance().MATRIX[2, 8].onThis);
            //bottom row
            for (int x = 0; x < Stage.MATRIX_SIZE; x++)
            {
                spawnEntity(x, Stage.MATRIX_SIZE - 1, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            spawnEntity(1, 1, Stage.player);
            Stage.player.scanForInteraction();
        }
    }
}
