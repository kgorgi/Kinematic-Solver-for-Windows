using System;

namespace Kinematic_Solver_for_Windows
{
    public class SolveDisplacement:KinematicComputer
    {
        private double ans;
        public double CalculateDisplacement()
        {
           this.CanCompute();
            if (this.tObj == null)
            {
                if(this.A == 0)
                {
                    throw new DivideByZeroException("Acceleration Cannot Equal Zero!");
                }
                this.ans = ((this.Vf * this.Vf) - (this.Vi * this.Vi)) / (2 * this.A);
            }
            else if (this.aObj == null)
            {
                this.ans = ((this.Vi + this.Vf) / 2) * this.T;
            }
            else if (this.viObj == null)
            {
                this.ans = (this.Vf * this.T) - (0.5 * this.A * (this.T * this.T));
            }
            else if (this.vfObj == null)
            {
                this.ans = (this.Vi * this.T) + (0.5 * this.A * (this.T * this.T));
            } 
            return this.ans;
        }
    }
}
