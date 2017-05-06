using System;
using Kinematic_Solver_for_Windows.Exceptions;

namespace Kinematic_Solver_for_Windows
{
    public class SolveInitialVelocity:KinematicComputer
    {
        private double ans;
        public double CalculateInitialVelocity()
        {
            this.CanCompute();
            if (this.dObj == null)
            {
                this.ans = this.Vf - (this.A * this.T);
            }
            else if (this.tObj == null)
            {
                double insideRadical = (Vf * Vf) - (2 * A * D);
                this.CheckRadical(insideRadical);
                double radical = Math.Sqrt(insideRadical);
                throw new TwoPossibleAnswersException(radical, radical * -1);
            }
            else if (this.aObj == null)
            {
                this.ans = ((2 * this.D) / this.T) - this.Vf;
            }
            else if (this.vfObj == null)
            {
                this.ans = (this.D - (0.5 * this.A * (this.T * this.T))) / this.T;
            } 
            return this.ans;
        }
    }
}
