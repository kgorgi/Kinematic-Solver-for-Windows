using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows
{
    public class DoubleNumber
    {
        private double _num;

        public DoubleNumber(double num)
        {
            _num = num;
        }

        public double num
        {
            get { return _num; }
        }

    }
}
