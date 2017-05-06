using System;
using Kinematic_Solver_for_Windows.Exceptions;

namespace Kinematic_Solver_for_Windows
{
    public class KinematicComputer
    {
        protected DoubleNumber dObj = null;
        protected DoubleNumber tObj = null;
        protected DoubleNumber aObj = null;
        protected DoubleNumber viObj = null;
        protected DoubleNumber vfObj = null;

        public double D
        {
            get { return this.dObj.Num; }
            set { this.dObj = new DoubleNumber(value); }
        }

        public double T
        {
            get { return this.tObj.Num; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Time cannot be set to zero or negative.");
                }
                this.tObj = new DoubleNumber(value);
            }
        }

        public double A
        {
            get { return this.aObj.Num; }
            set { this.aObj = new DoubleNumber(value); }
        }

        public double Vi
        {
            get { return this.viObj.Num; }
            set { this.viObj = new DoubleNumber(value); }
        }

        public double Vf
        {
            get { return this.vfObj.Num; }
            set { this.vfObj = new DoubleNumber(value); }
        }

        public void ClearVariables()
        {
            this.dObj = null;
            this.tObj = null;
            this.aObj = null;
            this.viObj = null;
            this.vfObj = null;
        }

        public void CanCompute()
        {
            int count = 0;
            if(this.dObj != null)
            {
                count++;
            }            
            if (this.tObj != null)
            {
                count++;
            }
            if (this.aObj != null)
            {
                count++;
            }
            if (this.viObj != null)
            {
                count++;
            }
            if (this.vfObj != null)
            {
                count++;
            }

            if (count != 3)
            {
                throw new VariablesNotSetException(count.ToString() + " out of 3 Variables Set!");
            }
        }

        protected void CheckRadical(double value)
        {
            if (value < 0)
            {
                throw new InvalidScenarioException();
            }
        }
    }
}
