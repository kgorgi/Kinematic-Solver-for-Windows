﻿using Kinematic_Solver_for_Windows.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows
{
    public class SolveTime:KinematicComputer
    {
        private double ans;
        public double CalculateTime()
        {
            this.CanCompute();
            if (_D == null)
            {
                if(this.A == 0)
                {
                    throw new DivideByZeroException();
                }
                ans = (this.Vf - this.Vi) / this.A;
            }
            else if (_A == null)
            {
                double dem = this.Vi + this.Vf;
                if(dem == 0)
                {
                    throw new DivideByZeroException();
                }
                ans = (2 * this.D) / (dem);
            }
            else if (_Vi == null)
            {
                if (this.A == 0)
                {
                    ans = Math.Abs(this.D / this.Vf);
                }
                else
                {
                    //Determine and send variables to quadratic equation
                    ans = QuadEquation((0.5 * this.A), (-1 * this.Vf), this.D);
                }
            }
            else if (_Vf == null)
            {
                if (this.A == 0)
                {
                    ans = Math.Abs(this.D / this.Vf);
                }
                else
                {
                    //Determine and send variables to quadratic equation
                    ans = QuadEquation((0.5 * this.A), this.Vi, (-1 * this.D));
                }
            } 
            return ans;
        }

        public static double QuadEquation(double a, double b, double c)
        {
            //Determine Roots
            double root1 = ((-1 * b) + Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);
            double root2 = ((-1 * b) - Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);

            //If roots are equal
            if (root1 == root2)
            {
                return root1;
            } 
            //Both roots are greater than zero (as time cannot be zero)
            else if (root1 >= 0 && root2 >= 0)
            {
                throw new TwoPossibleAnswersException(root1, root2);
            }
            //Return positive root only, because time is always positive
            else if (root1 >= 0 && root2 < 0)
            {
                return root1;
            }
            return root2;
        }
    }
}