using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factories.StructureFactory;

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
            spawnEntity(1, 1, Stage.player);
            Stage.player.initCloseCases();


            for (int x = 0; x < Stage.MATRIX_SIZE; x++)
            {
                spawnEntity(x, 0, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            for (int y = 1; y < Stage.MATRIX_SIZE - 1; y++)
            {
                for (int x = 0; x < Stage.MATRIX_SIZE; x = x + Stage.MATRIX_SIZE - 1)
                {
                    if (y == 4 && x == 9)
                    {
                        spawnEntity(x, y, Stage.getInstance().structureFactory.createStructure(StructureType.Door));
                        continue;
                    }
                    else spawnEntity(x, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
                }
            }
            for (int x = 0; x < Stage.MATRIX_SIZE; x++)
            {
                spawnEntity(x, Stage.MATRIX_SIZE - 1, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
        }
    }
}
