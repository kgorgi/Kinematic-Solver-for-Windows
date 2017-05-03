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
            this.CanCompute();
            if (this._D == null)
            {
                this.ans = (this.Vf - this.Vi) / this.T;
            }
            else if (this._T == null)
            {
                if(this.D == 0)
                {
                    throw new DivideByZeroException();
                }
                this.ans = ((this.Vf * this.Vf) - (this.Vi * this.Vi)) / (2 * this.D);
            }
            else if (this._Vi == null)
            { 
                this.ans = (this.D - (this.Vf * this.T)) / (-1 * 0.5 * (this.T * this.T));
            }
            else if (this._Vf == null)
            {
                this.ans = (this.D - (this.Vi * this.T)) / (0.5 * (this.T * this.T));
            } 
            return this.ans;
        }
    }
}
