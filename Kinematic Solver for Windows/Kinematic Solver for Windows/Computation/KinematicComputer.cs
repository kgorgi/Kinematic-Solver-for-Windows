using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinematic_Solver_for_Windows.Exceptions;

namespace Kinematic_Solver_for_Windows
{
    public class KinematicComputer
    {
        protected DoubleNumber _D = null;
        protected DoubleNumber _T = null;
        protected DoubleNumber _A = null;
        protected DoubleNumber _Vi = null;
        protected DoubleNumber _Vf = null;

        public double D
        {
            get { return this._D.Num; }
            set { this._D = new DoubleNumber(value); }
        }

        public double T
        {
            get { return this._T.Num; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Time cannot be set to zero or negative.");
                }
                this._T = new DoubleNumber(value);
            }
        }

        public double A
        {
            get { return this._A.Num; }
            set { this._A = new DoubleNumber(value); }
        }

        public double Vi
        {
            get { return this._Vi.Num; }
            set { this._Vi = new DoubleNumber(value); }
        }

        public double Vf
        {
            get { return this._Vf.Num; }
            set { this._Vf = new DoubleNumber(value); }
        }

        public void ClearVariables()
        {
            this._D = null;
            this._T = null;
            this._A = null;
            this._Vi = null;
            this._Vf = null;
        }

        public void CanCompute()
        {
            int count = 0;
            if(this._D != null)
            {
                count++;
            }            
            if (this._T != null)
            {
                count++;
            }
            if (this._A != null)
            {
                count++;
            }
            if (this._Vi != null)
            {
                count++;
            }
            if (this._Vf != null)
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
