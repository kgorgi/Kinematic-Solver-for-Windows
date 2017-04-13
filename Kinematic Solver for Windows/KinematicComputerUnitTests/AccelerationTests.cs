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

        private static SolveAcceleration InitTest(double D, double T, double Vi, double Vf, int skip)
        {
            SolveAcceleration compute = new SolveAcceleration();
            if (skip != 0)
            {
                compute.D = D;
            }
            if (skip != 1)
            {
                compute.T = T;
            }
            if (skip != 2)
            {
                compute.Vi = Vi;
            }
            if (skip != 3)
            {
                compute.Vf = Vf;
            }

            return compute;
        }

        private static void IterateVariables(double D, double T, double Vi, double Vf, double ans)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                SolveAcceleration com = InitTest(D, T, Vi, Vf, i);
                Assert.AreEqual(ans, com.CalculateAcceleration(), "Variable Skipped #: " + i.ToString());
            }
        }
    }
}
