using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinematic_Solver_for_Windows.Exceptions;

namespace Kinematic_Solver_for_Windows
{
    public class SolveInitialVelocity:KinematicComputer
    {
        private double ans;
        public double CalculateInitialVelocity()
        {
            this.CanCompute();
            if (this._D == null)
            {
                this.ans = this.Vf - (this.A * this.T);
            }
            else if (this._T == null)
            {
                double insideRadical = (Vf * Vf) - (2 * A * D);
                this.CheckRadical(insideRadical);
                double radical = Math.Sqrt(insideRadical);
                throw new TwoPossibleAnswersException(radical, radical * -1);
            }
            else if (this._A == null)
            {
                this.ans = ((2 * this.D) / this.T) - this.Vf;
            }
            else if (this._Vf == null)
            {
                this.ans = (this.D - (0.5 * this.A * (this.T * this.T))) / this.T;
            } 
            return this.ans;
        }
    }
}
