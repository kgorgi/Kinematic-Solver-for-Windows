using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;
using Kinematic_Solver_for_Windows.Exceptions;

namespace KinematicComputerUnitTests
{
    //Test Class for the Initalization of KinematicComputer (also checks edge cases)

    [TestClass]
    public class InitializationTests
    {
        [TestMethod]
        public void InitDisplacement()
        {
            double displace = 100;
            KinematicComputer compute = new KinematicComputer();
            compute.D = displace;
            Assert.AreEqual(displace, compute.D, 0, "Displacement failed to be set correctly.");
        }

        [TestMethod]
        public void InitTime()
        {
            double time = 5;
            KinematicComputer compute = new KinematicComputer();
            compute.T = time;
            Assert.AreEqual(time, compute.T, 0, "Time failed to be set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitTimeException()
        {
            double time = 0;
            KinematicComputer compute = new KinematicComputer();
            compute.T = time;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegTimeException()
        {
            double time = -5;
            KinematicComputer compute = new KinematicComputer();
            compute.T = time;
        }

        [TestMethod]
        public void InitAcceleration()
        {
            double accel = 52;
            KinematicComputer compute = new KinematicComputer();
            compute.A = accel;
            Assert.AreEqual(accel, compute.A, 0, "Acceleration failed to be set correctly.");
        }

        [TestMethod]
        public void InitInitialVelocity()
        {
            double initVelo = -30;
            KinematicComputer compute = new KinematicComputer();
            compute.Vi = initVelo;
            Assert.AreEqual(initVelo, compute.Vi, 0, "Initial Velocity failed to be set correctly.");
        }

        [TestMethod]
        public void InitFinalVelocity()
        {
            double finVelo = 1997;
            KinematicComputer compute = new KinematicComputer();
            compute.Vf = finVelo;
            Assert.AreEqual(finVelo, compute.Vf, 0, "Final Velocity failed to be set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(VariablesNotSetException))]
        public void NotEnoughtVariablesSet()
        {
            KinematicComputer compute = new KinematicComputer();
            compute.Vf = 0;
            compute.CanCompute();
        }

        [TestMethod]
        [ExpectedException(typeof(VariablesNotSetException))]
        public void TooManyVariablesSet()
        {
            KinematicComputer compute = new KinematicComputer();
            compute.D = 0;
            compute.T = 2;
            compute.A = 0;
            compute.Vf = 0;
            compute.CanCompute();
        }

        [TestMethod]
        public void ClearVariables()
        {
            KinematicComputer compute = new KinematicComputer();
            compute.D = 0;
            compute.T = 2;
            compute.A = 0;
            compute.Vi = 5;
            compute.Vf = 0;

            compute.ClearVariables();

            try
            {
                Assert.AreEqual(compute.D, null);
            }
            catch (NullReferenceException) { }

            try
            {
                Assert.AreEqual(compute.T, null);
            }
            catch (NullReferenceException) { }

            try
            {
                Assert.AreEqual(compute.A, null);
            }
            catch (NullReferenceException) { }

            try
            {
                Assert.AreEqual(compute.Vi, null);
            }
            catch (NullReferenceException) { }

            try
            {
                Assert.AreEqual(compute.Vf, null);
            }
            catch (NullReferenceException) { }

        }
    }

    [TestClass]
    public class NULLTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullDisplacement()
        {
            KinematicComputer compute = new KinematicComputer();
            double temp = compute.D;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullTime()
        {
            KinematicComputer compute = new KinematicComputer();
            double temp = compute.T;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullAcceleration()
        {
            KinematicComputer compute = new KinematicComputer();
            double temp = compute.A;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullInitVelocity()
        {
            KinematicComputer compute = new KinematicComputer();
            double temp = compute.Vi;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullFinVelocity()
        {
            KinematicComputer compute = new KinematicComputer();
            double temp = compute.Vf;
        }
    }
}
