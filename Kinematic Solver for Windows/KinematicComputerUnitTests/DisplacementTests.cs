using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;

namespace KinematicComputerUnitTests
{
    [TestClass]
    public class DisplacementTests
    {
        [TestMethod]
        public void Basic()
        {
            IterateVariables(5, 15, 30, 105, 337.5);
        }

        [TestMethod]
        public void Decimals()
        {
            IterateVariables(5.5, 2, 3, 14, 46.75);
        }

        [TestMethod]
        public void Negative()
        {
            IterateVariables(5, -6, -4, -34, -95);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            SolveDisplacement SD = InitTest(-1, 0, 5, 5, 'T');
            SD.CalculateDisplacement();
        }

        /* For the Parameter Skip:
         * Time = T
         * Acceleration = A
         * Initial Velocity = I
         * Final Velocity = F
         */
        private static SolveDisplacement InitTest(double T, double A, double Vi, double Vf, char skip)
        {
            SolveDisplacement compute = new SolveDisplacement();
            if(skip != 'T')
            {
                compute.T = T;
            }
            if (skip != 'A')
            {
                compute.A = A;
            }
            if (skip != 'I')
            {
                compute.Vi = Vi;
            }
            if (skip != 'F')
            {
                compute.Vf = Vf;
            }

            return compute;
        }

        private static void IterateVariables(double T, double A, double Vi, double Vf, double ans)
        {
            char[] skip = { 'T', 'A', 'I', 'F' };

            int i;
            for (i = 0; i < 4; i++)
            {
                SolveDisplacement com = InitTest(T, A, Vi, Vf, skip[i]);
                Assert.AreEqual(ans, com.CalculateDisplacement(), "Variable Skipped: " + skip[i]);
            }
        }
    }
}
