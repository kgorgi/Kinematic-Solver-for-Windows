using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinematic_Solver_for_Windows.Exceptions;

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

        protected void CheckRadical(double value)
        {
            if(value < 0)
            {
                throw new InvalidScenarioException();
            }
        }

        public void CanCompute()
        {
            int count = 0;
            if(_D != null)
                count++;
            if (_T != null)
                count++;
            if (_A != null)
                count++;
            if (_Vi != null)
                count++;
            if (_Vf != null)
                count++;
            
            if(count != 3)
            {
                throw new VariablesNotSetException("Only " + count.ToString() + "out of 3 Variables Set!");
            }
        }
    }
}
