﻿using The_Golden_Chicory;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    class CaseFactory
    {
        public Case createCase(int x, int y)
        {
            if (Validator.isCaseValidCreateCase(x,y))
            {
                return new Case(x, y);
            }
            else return null;
        }

        //for init the map when I load another level
        public Case recreateCase(int x, int y)
        {
            return new Case(x, y);
        }
    }
}
