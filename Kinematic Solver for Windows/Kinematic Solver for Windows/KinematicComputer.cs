using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows
{
    public class KinematicComputer
    {
        protected DoubleNumber _D = null;
        protected DoubleNumber _T = null;
        protected DoubleNumber _A = null;
        protected DoubleNumber _Vi = null;
        protected DoubleNumber _Vf = null;

        public double D
        {
            get { return _D.num; }
            set { _D = new DoubleNumber(value); }
        }

        public double T
        {
            get { return _T.num; }
            set {
               if(value <= 0)
                {
                    throw new ArgumentException("Time cannot be set to zero or negative.");
                }
                _T = new DoubleNumber(value);
            }
        }

        public double A
        {
            get { return _A.num; }
            set { _A = new DoubleNumber(value); }
        }

        public double Vi
        {
            get { return _Vi.num; }
            set { _Vi = new DoubleNumber(value); }
        }

        public double Vf
        {
            get { return _Vf.num; }
            set { _Vf = new DoubleNumber(value); }
        }
    }
}
