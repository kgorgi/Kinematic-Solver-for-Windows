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

        private void ratioButtonClicked(object sender, EventArgs e)
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
                    displacementTextBox.Text = "";
                    break;
                case "timeBtn":
                    timeTextBox.Enabled = false;
                    timeTextBox.Text = "";
                    break;
                case "accelBtn":
                    accelTextBox.Enabled = false;
                    accelTextBox.Text = "";
                    break;
                case "initVeloBtn":
                    initVeloTextBox.Enabled = false;
                    initVeloTextBox.Text = "";
                    break;
                case "finVeloBtn":
                    finVeloTextBox.Enabled = false;
                    finVeloTextBox.Text = "";
                    break;
                default:
                    initVeloTextBox.Enabled = false;
                    initVeloTextBox.Text = "";
                break;
            }           
        }

        private void clearFields(object sender, EventArgs e)
        {
            displacementTextBox.Text = "";
            timeTextBox.Text = "";
            accelTextBox.Text = "";
            initVeloTextBox.Text = "";
            finVeloTextBox.Text = "";
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            RadioButton[] radList = { displacementBtn, timeBtn, accelBtn, initVeloBtn, finVeloBtn };
            
            String ClassName = null;
            Type classType = null;
            double answer = 0;
            int pos = 0;

            //Reflectively Create Appropriate Class
            KinematicComputer calc = null;
            
            foreach(RadioButton radio in radList)
            {
                if (radio.Checked)
                {
                    String VariableName = radio.Text.Replace(" ", string.Empty);
                    ClassName = VariableName.Substring(0, VariableName.Length - 1);
                    //System.Diagnostics.Debug.WriteLine(ClassName.ToString());
                    classType = Type.GetType("Kinematic_Solver_for_Windows.Solve"+ ClassName);
                    calc = (KinematicComputer)Activator.CreateInstance(classType);
                    break;  
                }
                pos++;
            }

            //Set Variables (Try Catch)
            if (!displacementBtn.Checked && String.Compare(displacementTextBox.Text, "") != 0 )
            {
                calc.D = double.Parse(displacementTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!timeBtn.Checked && String.Compare(timeTextBox.Text, "") != 0)
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
            if (!accelBtn.Checked && String.Compare(accelTextBox.Text, "") != 0)
            {
                calc.A = double.Parse(accelTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!initVeloBtn.Checked && String.Compare(initVeloTextBox.Text, "") != 0)
            {
                calc.Vi = double.Parse(initVeloTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!finVeloBtn.Checked && String.Compare(finVeloTextBox.Text, "") != 0)
            {
                calc.Vf = double.Parse(finVeloTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            }

            //Reflectively Call Calculate Method on Child Class of KinematicComputer
            MethodInfo CalcMethod = classType.GetMethod("Calculate" + ClassName);
            //System.Diagnostics.Debug.WriteLine("Calculate" + ClassName);  
            try
            {
                answer = (double)CalcMethod.Invoke(calc, null);
            }
            catch (TargetInvocationException ex)
            {
                Exception innerEx = ex.InnerException;
                if(innerEx is DivideByZeroException)
                {
                    String msg = "Invalid Physics Scenario: Cannot Divide by Zero!";
                    MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(innerEx is InvalidScenarioException)
                {
                    String msg = "Invalid Physics Scenario: Cannot Square Root a Zero or Negative Number!";
                    MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                else if(innerEx is VariablesNotSetException)
                {
                    String msg = "Please Enter Exactly 3 Variables for Calculation";
                    MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(innerEx is TwoPossibleAnswersException)
                {
                    TwoPossibleAnswersException TwoEx = (TwoPossibleAnswersException)innerEx;
                    String msg = "Two Possible Answers!\n Answer 1: " + TwoEx.FirstValue.ToString() +
                                "     Answer 2: " + TwoEx.SecondValue.ToString() + "\n Is Answer 1 the correct answer?\n" +
                                " Select Yes if Answer 1 is.\n Otherwise select No if Answer 2 is correct. ";
                    switch(MessageBox.Show(msg, "Two Possible Answers!", MessageBoxButtons.YesNoCancel, 
                                        MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            answer = TwoEx.FirstValue;
                            break;
                        case DialogResult.No:
                            answer = TwoEx.SecondValue;
                            break;
                        default:
                            return;
                    }
                }
            }

            //Display Answer
            String[] Units = { "m", "s", "m/s^2", "m/s", "m/s" };
            ClassName = ClassName.Replace("V", " V");
            String ansStr = "The " + ClassName.ToLower() + " is: " + answer.ToString() + " " + Units[pos];
            MessageBox.Show(ansStr, "Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "Kinematic Solver for Windows\n\n" +
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
