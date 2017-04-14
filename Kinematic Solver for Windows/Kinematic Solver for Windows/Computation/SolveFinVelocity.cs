using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinematic_Solver_for_Windows.Exceptions;

namespace Kinematic_Solver_for_Windows
{
    public class SolveFinVelocity:KinematicComputer
    {
        private double ans;
        public double CalculateFinVelocity()
        {
            this.CanCompute();
            if (_D == null)
            {
                ans = (this.A * this.T) + this.Vi;
            }
            else if (_T == null)
            {
                double insideRadical = (this.Vi * this.Vi) + (2 * this.A * this.D);
                CheckRadical(insideRadical);
                ans = Math.Sqrt(insideRadical);
                throw new TwoPossibleAnswersException(ans, ans * -1);
            }
            else if (_A == null)
            {
                ans = ((2 * this.D) / this.T) - this.Vi;
            }
            else if (_Vi == null)
            {
                ans = (this.D + (0.5 * this.A * (this.T * this.T))) / this.T;
            } 
            return ans;
        }
    }
}
