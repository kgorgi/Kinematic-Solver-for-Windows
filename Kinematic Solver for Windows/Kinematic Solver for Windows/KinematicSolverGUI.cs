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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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
            double answer;
            int pos = 0;

            //Reflectively Create Appropriate Class
            KinematicComputer calc = null;
            
            foreach(RadioButton radio in radList)
            {
                if (radio.Checked)
                {
                    String VariableName = radio.Text.Replace(" ", string.Empty);
                    ClassName = VariableName.Substring(0, VariableName.Length - 1);
                    System.Diagnostics.Debug.WriteLine(ClassName.ToString());
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
                //TRY CATCH
                calc.T = double.Parse(timeTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
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
            answer = (double) CalcMethod.Invoke(calc, null);

            //Display Answer
            String[] Units = { "m", "s", "m/s^2", "m/s", "m/s" };
            MessageBox.Show("The answer is: " + answer.ToString() + " " + Units[pos], ClassName);
        }
    }
}
