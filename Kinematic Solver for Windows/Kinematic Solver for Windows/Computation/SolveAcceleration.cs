using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows
{
    public class SolveAcceleration:KinematicComputer
    {
        private double ans;
        public double CalculateAcceleration()
        {

            if (_D == null)
            {
                ans = (this.Vf - this.Vi) / this.T;
            }
            else if (_T == null)
            {
                if(this.D == 0)
                {
                    throw new DivideByZeroException();
                }
                ans = ((this.Vf * this.Vf) - (this.Vi * this.Vi)) / (2 * this.D);
            }
            else if (_Vi == null)
            { 
                ans = (this.D - (this.Vf * this.T)) / (-1 * 0.5 * (this.T * this.T));
            }
            else if (_Vf == null)
            {
                ans = (this.D - (this.Vi * this.T)) / (0.5 * (this.T * this.T));
            } 
            return ans;
        }
    }
}
