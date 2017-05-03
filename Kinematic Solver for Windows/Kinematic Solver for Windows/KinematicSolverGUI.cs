using Kinematic_Solver_for_Windows.Exceptions;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Kinematic_Solver_for_Windows
{
    public partial class KinematicSolverGUI : Form
    {
        public KinematicSolverGUI()
        {
            InitializeComponent();
            displacementBtn.Select();
            displacementTextBox.Enabled = false;
        }

        private void RatioButton_Click(object sender, EventArgs e)
        {
            displacementTextBox.Enabled = true;
            timeTextBox.Enabled = true;
            accelTextBox.Enabled = true;
            initVeloTextBox.Enabled = true;
            finVeloTextBox.Enabled = true;

            RadioButton btn = (RadioButton)sender;
            switch (btn.Name)
            {
                case "displacementBtn":
                    displacementTextBox.Enabled = false;
                    displacementTextBox.Text = string.Empty;
                    break;
                case "timeBtn":
                    timeTextBox.Enabled = false;
                    timeTextBox.Text = string.Empty;
                    break;
                case "accelBtn":
                    accelTextBox.Enabled = false;
                    accelTextBox.Text = string.Empty;
                    break;
                case "initVeloBtn":
                    initVeloTextBox.Enabled = false;
                    initVeloTextBox.Text = string.Empty;
                    break;
                case "finVeloBtn":
                    finVeloTextBox.Enabled = false;
                    finVeloTextBox.Text = string.Empty;
                    break;
                default:
                    initVeloTextBox.Enabled = false;
                    initVeloTextBox.Text = string.Empty;
                break;
            }           
        }

        private void ClearFields(object sender, EventArgs e)
        {
            displacementTextBox.Text = string.Empty;
            timeTextBox.Text = string.Empty;
            accelTextBox.Text = string.Empty;
            initVeloTextBox.Text = string.Empty;
            finVeloTextBox.Text = string.Empty;
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            RadioButton[] radList = { displacementBtn, timeBtn, accelBtn, initVeloBtn, finVeloBtn };
            
            string className = null;
            Type classType = null;
            double answer = 0;
            int pos = 0;

            // Reflectively Create Appropriate Class
            KinematicComputer calc = null;
            
            foreach(RadioButton radio in radList)
            {
                if (radio.Checked)
                {
                    string variableName = radio.Text.Replace(" ", string.Empty);
                    className = variableName.Substring(0, variableName.Length - 1);
                    // System.Diagnostics.Debug.WriteLine(ClassName.ToString());
                    classType = Type.GetType("Kinematic_Solver_for_Windows.Solve"+ className);
                    calc = (KinematicComputer)Activator.CreateInstance(classType);
                    break;  
                }
                pos++;
            }

            // Set Variables (Try Catch)
            if (!displacementBtn.Checked && string.Compare(displacementTextBox.Text, string.Empty) != 0)
            {
                calc.D = double.Parse(displacementTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!timeBtn.Checked && string.Compare(timeTextBox.Text, string.Empty) != 0)
            {
                try
                {
                    calc.T = double.Parse(timeTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Time Cannot be Zero or Negative!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }  
            }
            if (!accelBtn.Checked && string.Compare(accelTextBox.Text, string.Empty) != 0)
            {
                calc.A = double.Parse(accelTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!initVeloBtn.Checked && string.Compare(initVeloTextBox.Text, string.Empty) != 0)
            {
                calc.Vi = double.Parse(initVeloTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!finVeloBtn.Checked && string.Compare(finVeloTextBox.Text, string.Empty) != 0)
            {
                calc.Vf = double.Parse(finVeloTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }

            // Reflectively Call Calculate Method on Child Class of KinematicComputer
            MethodInfo calcMethod = classType.GetMethod("Calculate" + className);
            // System.Diagnostics.Debug.WriteLine("Calculate" + ClassName);  
            try
            {
                answer = (double)calcMethod.Invoke(calc, null);
            }
            catch (TargetInvocationException ex)
            {
                Exception innerEx = ex.InnerException;
                if(innerEx is DivideByZeroException)
                {
                    string msg = "Invalid Physics Scenario: Cannot Divide by Zero!";
                    MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(innerEx is InvalidScenarioException)
                {
                    string msg = "Invalid Physics Scenario: Cannot Square Root a Zero or Negative Number!";
                    MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                else if(innerEx is VariablesNotSetException)
                {
                    string msg = "Please Enter Exactly 3 Variables for Calculation";
                    MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(innerEx is TwoPossibleAnswersException)
                {
                    TwoPossibleAnswersException twoEx = (TwoPossibleAnswersException)innerEx;
                    string msg = "Two Possible Answers!\n Answer 1: " + twoEx.FirstValue.ToString() +
                                "     Answer 2: " + twoEx.SecondValue.ToString() + "\n Is Answer 1 the correct answer?\n" +
                                " Select Yes if Answer 1 is.\n Otherwise select No if Answer 2 is correct. ";
                    switch(MessageBox.Show(msg, "Two Possible Answers!", MessageBoxButtons.YesNoCancel, 
                                        MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            answer = twoEx.FirstValue;
                            break;
                        case DialogResult.No:
                            answer = twoEx.SecondValue;
                            break;
                        default:
                            return;
                    }
                }
            }

            // Display Answer
            string[] units = { "m", "s", "m/s^2", "m/s", "m/s" };
            className = className.Replace("V", " V");
            string ansStr = "The " + className.ToLower() + " is: " + answer.ToString() + " " + units[pos];
            MessageBox.Show(ansStr, "Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Kinematic Solver for Windows\n\n" +
                         "Version 1.0.0\n\n" +
                         "Design, Programming, Testing\n" +
                         "Done By Kian Gorgichuk\n\n" +
                         "Special Thanks to Ms. Bater!\n\n" +
                         "Copyright (c) 2017 Kian Gorgichuk\n" +
                         "All rights reserved.";

            MessageBox.Show(msg, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void KinematicSolverGUI_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
        }
    }
}
