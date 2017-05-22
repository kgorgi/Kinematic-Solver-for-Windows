using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;

namespace KinematicComputerUnitTests
{
    [TestClass]
    public class AccelerationTests
    {
        [TestMethod]
        public void Basic()
        {
            IterateVariables(337.5, 5, 30, 105, 15);
        }

        [TestMethod]
        public void Decimals()
        {
            IterateVariables(46.75, 5.5, 3, 14, 2);
        }

        [TestMethod]
        public void Negative()
        {
            IterateVariables(-95, 5, -4, -34, -6);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            SolveAcceleration SA = InitTest(0, -1, 5, 5, 'T');
            SA.CalculateAcceleration();
        }

        /* For the Parameter Skip:
         * Displacement = D
         * Time = T
         * Initial Velocity = I
         * Final Velocity = F
         */
        private static SolveAcceleration InitTest(double D, double T, double Vi, double Vf, char skip)
        {
            SolveAcceleration compute = new SolveAcceleration();
            if (skip != 'D')
            {
                compute.D = D;
            }
            if (skip != 'T')
            {
                compute.T = T;
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

        private static void IterateVariables(double D, double T, double Vi, double Vf, double ans)
        {
            char[] skip = { 'D', 'T', 'I', 'F' };

            int i;
            for (i = 0; i < 4; i++)
            {
                SolveAcceleration com = InitTest(D, T, Vi, Vf, skip[i]);
                Assert.AreEqual(ans, com.CalculateAcceleration(), "Variable Skipped: " + skip[i]);
            }
        }
    }
}
