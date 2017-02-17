using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows
{
    public class KinematicComputer
    {
        private double _D;
        private double _T;
        private double _A;
        private double _Vi;
        private double _Vf;
        
        public double Displacement
        {
            get { return _D; }
            set { _D = value; }
        }

        public double Time
        {
            get { return _T; }
            set {
               if(value == 0)
                {
                    throw new ArgumentException("Time cannot be set to zero.");
                }
                _T = value;
            }
        }

        public double Acceleration
        {
            get { return _A; }
            set { _A = value; }
        }

        public double InitVelocity
        {
            get { return _Vi; }
            set { _Vi = value; }
        }

        public double FinVelocity
        {
            get { return _Vf; }
            set { _Vf = value; }
        }
    }
}
