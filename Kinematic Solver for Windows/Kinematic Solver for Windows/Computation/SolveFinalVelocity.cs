using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinematic_Solver_for_Windows.Exceptions;

namespace Kinematic_Solver_for_Windows
{
    public class SolveFinalVelocity:KinematicComputer
    {
        private double ans;
        public double CalculateFinalVelocity()
        {
            this.CanCompute();
            if (this._D == null)
            {
                this.ans = (this.A * this.T) + this.Vi;
            }
            else if (this._T == null)
            {
                double insideRadical = (this.Vi * this.Vi) + (2 * this.A * this.D);
                this.CheckRadical(insideRadical);
                this.ans = Math.Sqrt(insideRadical);
                throw new TwoPossibleAnswersException(this.ans, this.ans * -1);
            }
            else if (this._A == null)
            {
                this.ans = ((2 * this.D) / this.T) - this.Vi;
            }
            else if (this._Vi == null)
            {
                this.ans = (this.D + (0.5 * this.A * (this.T * this.T))) / this.T;
            } 
            return this.ans;
        }
    }
}
