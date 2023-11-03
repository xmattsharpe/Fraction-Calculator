using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Fraction_Calculator
{
    public partial class Form1 : Form { 

    // exceptions are included throughout my program so that the user does NOT divide by zero
    


        // value 1 holds the users first fractions numerator, value 2 holds the first fractions denominator, same for value 3 and 4 just for the second fraction
        double value1, value2, value3, value4;

        Stopwatch Watch = new Stopwatch();

        // operation holds the users desired mathematical operation
        string operation;

        // toggle is the button that I am using to determine whent the user has decided to enter in a denominator, since there are two textboxes with this application
        public bool toggle = false;

        Fraction total;

       


        public const string Caption = "ERROR 101, PLEASE RESTART";
        public Form1()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this event is attached to all the numerical buttons so that I need not create nearly 10 of the same events 
            
            Button Display = (Button)sender;

            
            if (toggle == false)
            {
                // append
                ShowNumerator.Text += Display.Text;
            }
            // if toggle is equal to true then the button was pressed that the user would like to enter the denominator at this point

            else if (toggle == true)
            {
                // append
                ShowDenominator.Text += Display.Text;

            }


        }
        private void button13_Click(object sender, EventArgs e)
        {
            // SUBTRACTION BUTTON


            operation = "-";

            value1 = Double.Parse(ShowNumerator.Text);

            try
            {
                value2 = Double.Parse(ShowDenominator.Text);
                if (value2 == 0)
                {
                    throw new DivideByZeroException();

                }
            }
            catch (DivideByZeroException ex)
            {
                
                MessageBox.Show(ex.Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

            // clear the text boxes
            ShowNumerator.Clear();
            ShowDenominator.Clear();

            toggle = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // MULTIPLICATION BUTTON
            operation = "*";
            value1 = Double.Parse(ShowNumerator.Text);

            try
            {
                value2 = Double.Parse(ShowDenominator.Text);
                if (value2 == 0)
                {
                    throw new DivideByZeroException();

                }
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

            // clear the text boxes
            ShowNumerator.Clear();
            ShowDenominator.Clear();

            toggle = false;

            

        }

        private void button16_Click(object sender, EventArgs e)
        {
            // CLEAR all values that are occupied or non occupied for precision.

            ShowNumerator.Clear();
            ShowDenominator.Clear();
            textBox5.Clear();
            value1 = 0;
            value2 = 0;
            value3 = 0;
            value4 = 0;
            label6.Text = "";
            toggle = false;
            label9.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            textBox5.Visible = false; 
            label7.Visible = false;
            pictureBox1.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // click me button
            toggle = true;
        }

        private void ShowNumerator_TextChanged(object sender, EventArgs e)
        {
            Watch.Start();
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // DIVIDE BUTTON
            operation = "/";
            value1 = Double.Parse(ShowNumerator.Text);

            try
            {
                value2 = Double.Parse(ShowDenominator.Text);
                if (value2 == 0)
                {
                    throw new DivideByZeroException();

                }
            }

            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // clear the text boxes
            ShowNumerator.Clear();
            ShowDenominator.Clear();

            toggle = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // ADDITION BUTTON

            operation = "+";
            value1 = Double.Parse(ShowNumerator.Text);

            try
            {
                value2 = Double.Parse(ShowDenominator.Text);
                if (value2 == 0)
                {
                    throw new DivideByZeroException();

                }
            }

            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


            // clearing the text boxes
            ShowNumerator.Clear();
            ShowDenominator.Clear();

            toggle = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // EQUALs BUTTON


            value3 = Double.Parse(ShowNumerator.Text);

            label5.Visible = true;
            textBox5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label4.Visible = true;
            label4.Text = "Entered problem: ";
            pictureBox1.Visible = true;

            try
            {
                value4 = Double.Parse(ShowDenominator.Text);
                if (value4 == 0)
                {
                    throw new DivideByZeroException();
                    
                }
            }

            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // INSTANTIATING MY FRACTION CLASS 
            Fraction f1 = new Fraction(value1, value2);
            Fraction f2 = new Fraction(value3, value4);

            label9.Visible = true;
            label9.Text = "Interesting fact, it took you " + Watch.Elapsed.Seconds + " seconds to enter your problem";
            Watch.Reset();


            // this instance will hold the total of f1 and f2 after whichever operation is performed
            
            switch (operation)
            {
                case "+" :
                    total = f1 + f2;
                    label6.Text = $"{value1} / {value2} + {value3} / {value4}";
                    textBox5.Text = total.Nums.ToString() + " / " + total.Denom.ToString();
                    break;

                case "-":  
                    total = f1 - f2;
                    label6.Text = $"{value1} / {value2} - {value3} / {value4}";
                    textBox5.Text = total.Nums.ToString() + " / " + total.Denom.ToString();
                    break;


                case "*":
                    total = f1 * f2;
                    label6.Text = $"{value1} / {value2} * {value3} / {value4}";
                    textBox5.Text = total.Nums.ToString() + " / " + total.Denom.ToString();
                    break;


                case "/":
                    total = f1 / f2;
                    label6.Text = $"{value1} / {value2} / {value3} / {value4}";
                    textBox5.Text = total.Nums.ToString() + " / " + total.Denom.ToString();
                    break;
            }




        }

    }
}
