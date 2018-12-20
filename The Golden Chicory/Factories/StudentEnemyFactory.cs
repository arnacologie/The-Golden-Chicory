using Characters;
using Student_Ennemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    public class StudentEnemyFactory
    {
        public enum StudentEnemyType {AnnoyingStudent}

        public StudentEnemy createStudentEnemy(StudentEnemyType studentEnemyType)
        {
            switch (studentEnemyType)
            {
                case StudentEnemyType.AnnoyingStudent:
                    return new AnnoyingStudent(0,0,"Annoying Student", 5, true);
                default:
                    return null;
            }
        }
    }
}
