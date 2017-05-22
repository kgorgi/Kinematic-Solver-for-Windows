using System;

namespace Kinematic_Solver_for_Windows
{
    public class SolveAcceleration:KinematicComputer
    {
        private double ans;
        public double CalculateAcceleration()
        {
            this.CanCompute();
            if (this.dObj == null)
            {
                this.ans = (this.Vf - this.Vi) / this.T;
            }
            else if (this.tObj == null)
            {
                if(this.D == 0)
                {
                    throw new DivideByZeroException("Displacement Cannot Equal Zero!");
                }
                this.ans = ((this.Vf * this.Vf) - (this.Vi * this.Vi)) / (2 * this.D);
            }
            else if (this.viObj == null)
            { 
                this.ans = (this.D - (this.Vf * this.T)) / (-1 * 0.5 * (this.T * this.T));
            }
            else if (this.vfObj == null)
            {
                this.ans = (this.D - (this.Vi * this.T)) / (0.5 * (this.T * this.T));
            } 
            return this.ans;
        }
    }
}
