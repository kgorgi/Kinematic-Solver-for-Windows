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
            this._num = num;
        }

        public double Num
        {
            get { return this._num; }
        }

    }
}
