using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows
{
    public class SolveDisplacement:KinematicComputer
    {
        private double ans;
        public double CalculateDisplacement()
        {
           this. CanCompute();
            if (_T == null)
            {
                if(this.A == 0)
                {
                    throw new DivideByZeroException();
                }
                ans = ((this.Vf * this.Vf) - (this.Vi * this.Vi)) / (2 * this.A);
            }
            else if (_A == null)
            {
                ans = ((this.Vi + this.Vf) / 2) * this.T;
            }
            else if (_Vi == null)
            {
                ans = (this.Vf * this.T) - (0.5 * this.A * (this.T * this.T));
            }
            else if (_Vf == null)
            {
                ans = (this.Vi * this.T) + (0.5 * this.A * (this.T * this.T));
            } 
            return ans;
        }
    }
}
