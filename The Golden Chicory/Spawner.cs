using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factories.StructureFactory;
using static Factories.ItemFactory;
using Structures;
using Items;
using Quests;
using static Factories.StudentEnemyFactory;
using static Quests.QuestManager;

namespace The_Golden_Chicory
{
    public static class Spawner
    {
        public static bool alreadySpawnOnce = false;
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
                Console.WriteLine("{0} appeared !", entity.name);
                return true;
            }
        }

        public static void spawnLevelTest()
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
                    spawnEntity(x, 4, Stage.getInstance().structureFactory.createStructure(StructureType.DoorLockedVertical));
                    continue;
                }
                spawnEntity(x, 4, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            for (int y = 5; y < 9; y++)
            {
                spawnEntity(4, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            spawnEntity(2, 8, Stage.getInstance().itemFactory.createItem(ItemType.StudentCard));
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

        public static void spawnOutside()
        {
            //top row
            for (int x = 0; x < Stage.MATRIX_SIZE; x++)
            {
                spawnEntity(x, 0, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //left row
            for (int y = 1; y < 9; y++)
            {
                if(y==7) spawnEntity(1, y, Stage.getInstance().structureFactory.createStructure(StructureType.DormDoor));
                spawnEntity(0, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            for (int y = 1; y<7; y++)
            {
                spawnEntity(1, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //right row
            for (int y = 1; y<9; y++)
            {
                if (y == 2 || y == 3 || y == 4)
                {
                    spawnEntity(9, y, Stage.getInstance().structureFactory.createStructure(StructureType.DoorLockedVertical));
                    Stage.getInstance().MATRIX[9, y].onThis.name = Door.campusDoorName;
                }
                spawnEntity(9, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //other cases
            for (int x = 1; x < 10; x++)
            {
                if (x == 6 || x == 7) continue;
                spawnEntity(x, 8, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //register door in key
            //Registrator.doorInKey((Door)Stage.getInstance().MATRIX[5, 4].onThis, (Key)Stage.getInstance().MATRIX[2, 8].onThis);
            //Configure the player 
            spawnEntity(0,9, Stage.player);
            Stage.player.scanForInteraction();
            //Set the quests
            QuestManager.getInstance().quests[QuestManager.QUEST1].activateQuest();

        }

        public static void spawnFirstFloor()
        {
            //top row
            for (int x = 0; x < Stage.MATRIX_SIZE; x++)
            {
                if (x == 6) spawnEntity(x, 0, Stage.getInstance().structureFactory.createStructure(StructureType.FirstFloorStairs));
                else if (x == 2) continue;
                else if (x==1 || x==3) spawnEntity(x, 0, Stage.getInstance().structureFactory.createStructure(StructureType.DoorLockedVertical));
                else spawnEntity(x, 0, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //right row
            for (int y = 1; y < 9; y++)
            {
                if (y == 2 || y == 3 || y ==4 ) spawnEntity(0, y, Stage.getInstance().structureFactory.createStructure(StructureType.DoorUnlockedVertical));
                else spawnEntity(0, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //left row
            for (int y = 1; y < 9; y++)
            {
                if (y == 7) continue;
                spawnEntity(9, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //other cases
            for (int x = 1; x < 10; x++)
            {
                if (x == 3 || x == 8)
                {
                    spawnEntity(x, 8, Stage.getInstance().structureFactory.createStructure(StructureType.DoorUnlockedHorizontal));
                }
                else spawnEntity(x, 8, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            for(int x = 0; x<9; x++)
            {
                if (x == 4) spawnEntity(4, 1, Stage.getInstance().structureFactory.createStructure(StructureType.FirstFloorStairs));
                else if (x == 6) spawnEntity(6, 1, Stage.getInstance().structureFactory.createStructure(StructureType.DoorUnlockedHorizontal));
                else if (x == 2) continue;
                else spawnEntity(x, 1, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            for(int x = 1; x<9; x++)
            {
                if (x == 3 || x == 8)
                {
                    continue;
                }
                spawnEntity(x, 6, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            for(int x = 0; x<10; x++)
            {
                if (x == 3 || x == 8) continue;
                else if (x == 4 || x == 9) spawnEntity(x, 7, Stage.getInstance().structureFactory.createStructure(StructureType.FirstFloorStairs));
                else spawnEntity(x, 7, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            spawnEntity(7, 2, Stage.getInstance().structureFactory.createStructure(StructureType.DoorLockedVertical));
            spawnEntity(8, 2, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            //spawnStudentEnemies
            spawnEntity(4, 2, Stage.getInstance().studentEnemyFactory.createStudentEnemy(StudentEnemyType.AnnoyingStudent));
            spawnEntity(6, 2, Stage.getInstance().studentEnemyFactory.createStudentEnemy(StudentEnemyType.AnnoyingStudent));
            spawnEntity(3, 7, Stage.getInstance().studentEnemyFactory.createStudentEnemy(StudentEnemyType.AnnoyingStudent));
            spawnEntity(8, 7, Stage.getInstance().studentEnemyFactory.createStudentEnemy(StudentEnemyType.AnnoyingStudent));
            //register door in key
            //Registrator.doorInKey((Door)Stage.getInstance().MATRIX[5, 4].onThis, (Key)Stage.getInstance().MATRIX[2, 8].onThis);
            //Configure the player 
            spawnEntity(1, 3, Stage.player);
            Stage.player.scanForInteraction();
            //Set the quests
            QuestManager.getInstance().quests[QuestManager.QUEST2].activateQuest();

        }

        public static void spawnForthFloor()
        {
            //top row
            for (int x = 0; x < Stage.MATRIX_SIZE; x++)
            {
                spawnEntity(x, 0, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //left row
            for (int y = 1; y < 9; y++)
            {
                if (y == 2 || y == 3 || y == 4) spawnEntity(0, y, Stage.getInstance().structureFactory.createStructure(StructureType.DoorUnlockedVertical));
                else spawnEntity(0, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //right row
            for (int y = 1; y < 9; y++)
            {
                if (y == 2 || y == 3 || y == 4)
                {
                    spawnEntity(9, y, Stage.getInstance().structureFactory.createStructure(StructureType.DoorLockedVertical));
                    Stage.getInstance().MATRIX[9, y].onThis.name = Door.campusDoorName;
                }
                spawnEntity(9, y, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            //other cases
            for (int x = 1; x < 10; x++)
            {
                if (x == 6 || x == 7) continue;
                spawnEntity(x, 8, Stage.getInstance().structureFactory.createStructure(StructureType.Wall));
            }
            spawnEntity(6, 1, Stage.getInstance().structureFactory.createStructure(StructureType.FirstFloorStairs));
            //register door in key
            //Registrator.doorInKey((Door)Stage.getInstance().MATRIX[5, 4].onThis, (Key)Stage.getInstance().MATRIX[2, 8].onThis);
            //Configure the player 
            spawnEntity(1, 3, Stage.player);
            Stage.player.scanForInteraction();
            //Set the quests
            //QuestManager.getInstance().quests[QuestManager.QUEST2].activateQuest();
            QuestManager.getInstance().notify(EventProgressType.ForthFloorReached);

        }
    }
}
