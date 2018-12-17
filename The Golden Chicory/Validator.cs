using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Golden_Chicory
{
    class Validator
    {
        public static bool isCaseValidCreateCase(int x, int y)
        {
            return (x >= 0 && x < Stage.MATRIX_SIZE && y >= 0 && y < Stage.MATRIX_SIZE &&
                Stage.getInstance().MATRIX[x, y] == null);
        }

        public static bool isCaseEmpty(int x, int y)
        {
            return (x >= 0 && x < Stage.MATRIX_SIZE && y >= 0 && y < Stage.MATRIX_SIZE && (
                Stage.getInstance().MATRIX[x, y].onThis.GetType() == typeof(Floor)));
        }
         
        public static bool isCaseValidForMovement(int x, int y)
        {
            return (x >= 0 && x < Stage.MATRIX_SIZE && y >= 0 && y < Stage.MATRIX_SIZE && (
                Stage.getInstance().MATRIX[x, y].onThis.GetType() == typeof(Floor)) || isDoorOpened(x, y));
        }

        public static bool isCaseValid(int x, int y)
        {
            return (x >= 0 && x < Stage.MATRIX_SIZE && y >= 0 && y < Stage.MATRIX_SIZE &&
                Stage.getInstance().MATRIX[x, y].onThis.interactions.Count > 0);
        }

        private static bool isDoorOpened(int x, int y)
        {
            if (Stage.getInstance().MATRIX[x, y].onThis.GetType() == typeof(Door))
            {
                Door door = (Door)Stage.getInstance().MATRIX[x, y].onThis;
                return (door.isOpen);
            }
            else return false;
        }
    }
}
