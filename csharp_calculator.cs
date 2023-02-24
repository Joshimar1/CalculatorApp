using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class csharp_calculator : Form
    {
        public csharp_calculator()
        {
            InitializeComponent();
        }

        float num1 = 0;
        float num2 = 0;
        int oprClickCount = 0;
        bool isOprClicked = false;
        bool isEqualClicked = false;
        string opr;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void csharp_calculator_Load(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if (c is Button)
                {
                    if(c.Text != "Reset")
                    c.Click += new System.EventHandler(buttonClick);
                }
            }
        }

        public void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!isOperator(button))
            {
                if (isOprClicked)
                {
                    num1 = float.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                if (!textBox1.Text.Contains("."))
                {
                    if (textBox1.Text.Equals("0") && !button.Text.Equals("."))
                    { 
                        textBox1.Text = button.Text;
                        isOprClicked = false;
                    }
                    else
                    {
                        textBox1.Text += button.Text;
                        isOprClicked = false;
                    }
                }

                else if (!button.Text.Equals("."))
                {
                    textBox1.Text += button.Text;
                    isOprClicked = false;
                }
            }
            else
            {
                if (oprClickCount == 0)
                {
                    oprClickCount++;
                    num1 = float.Parse(textBox1.Text);
                    opr = button.Text;
                    isOprClicked = true;
                }
                else
                {
                    if (!button.Text.Equals(""))
                    {
                        if (!isEqualClicked)
                        {
                            num2 = float.Parse(textBox1.Text);
                            textBox1.Text = Convert.ToString(calc(opr, num1, num2));
                            num2 = float.Parse(textBox1.Text);
                            opr = button.Text;
                            isOprClicked = true;
                            isEqualClicked = false;
                        }
                        else
                        {
                            isEqualClicked = false;
                            opr = button.Text;
                        }
                    }
                }
            }

            
        }

        public bool isOperator(Button button)
        {
            string buttonText = button.Text;

            if(buttonText.Equals("+") || buttonText.Equals("-") ||
                buttonText.Equals("x") || buttonText.Equals("/") ||
                buttonText.Equals("="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float calc(string opr, float num1, float num2)
        {
            float result = 0;

            switch (opr)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "x":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        result = num1 / num2;
                    break;

            }
            return result;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            opr = "";
            isOprClicked = false;
            isEqualClicked = false;
            oprClickCount = 0;
            textBox1.Text = "0";

        }
    }
}
