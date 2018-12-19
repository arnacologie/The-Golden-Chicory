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
        public enum StructureType {DoorLocked, DoorUnlocked, DormDoor, Floor, Stairs, Wall}

        public StructureType structureType;

        public Structure createStructure(StructureType structureType)
        {
            switch (structureType)
            {
                case StructureType.DoorUnlocked:
                    return new Door(false, false, false);
                case StructureType.DoorLocked:
                    return new Door(true, false, false);
                case StructureType.DormDoor:
                    return new Door(true, false, true);
                case StructureType.Floor:
                    return new Floor();
                case StructureType.Stairs:
                    return new Stairs();
                case StructureType.Wall:
                    return new Wall();
                default:
                    Console.WriteLine("Error in {0} {1}", Stage.getFunctionName(), GetType().Name);
                    return null;
            }
        }
    }
}
