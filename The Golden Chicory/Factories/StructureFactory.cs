using The_Golden_Chicory;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    public class StructureFactory
    {
        public enum StructureType {DoorLockedVertical, DoorUnlockedVertical, DoorLockedHorizontal, Tablet, DoorUnlockedHorizontal, DormDoor, Floor, FirstFloorStairs, Wall}

        public Structure createStructure(StructureType structureType)
        {
            switch (structureType)
            {
                case StructureType.DoorUnlockedVertical:
                    return new Door(true, false, false, false);
                case StructureType.DoorLockedVertical:
                    return new Door(true, true, false, false);
                case StructureType.DoorUnlockedHorizontal:
                    return new Door(false, false, false, false);
                case StructureType.DoorLockedHorizontal:
                    return new Door(false, true, false, false);
                case StructureType.DormDoor:
                    return new Door(true, true, false, true);
                case StructureType.Floor:
                    return new Floor();
                case StructureType.FirstFloorStairs:
                    return new Stairs(1);
                case StructureType.Tablet:
                    return new Tablet();
                case StructureType.Wall:
                    return new Wall();
                default:
                    Console.WriteLine("Error in {0} {1}", Stage.getFunctionName(), GetType().Name);
                    return null;
            }
        }
    }
}
