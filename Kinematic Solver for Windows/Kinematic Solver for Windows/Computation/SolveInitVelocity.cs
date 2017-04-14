using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinematic_Solver_for_Windows.Exceptions;

namespace Kinematic_Solver_for_Windows
{
    public class SolveInitVelocity:KinematicComputer
    {
        private double ans;
        public double CalculateInitVelocity()
        {
            this.CanCompute();
            if (_D == null)
            {
                ans = this.Vf - (this.A * this.T);
            }
            else if (_T == null)
            {
                double insideRadical = (Vf * Vf) - (2 * A * D);
                CheckRadical(insideRadical);
                double radical = Math.Sqrt(insideRadical);
                throw new TwoPossibleAnswersException(radical, radical * -1);
            }
            else if (_A == null)
            {
                ans = ((2 * this.D) / this.T) - this.Vf;
            }
            else if (_Vf == null)
            {
                ans = (this.D - (0.5 * this.A * (this.T * this.T))) / this.T;
            } 
            return ans;
        }
    }
}
