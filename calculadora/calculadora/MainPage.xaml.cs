using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculadora
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firtNumber, secondNumber;
       
        public MainPage()
        {
            InitializeComponent();
            OnClear(new object(),new EventArgs ());

            
        }
        void OnClear(object sender, EventArgs e)
        {
            firtNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }
        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if(this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;

            }
            this.resultText.Text += pressed;
            Double number;
            if(double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                firtNumber = number;
            }
            else
            {
                secondNumber = number;
            }
        }
        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }
        void OnCalculete(object sender, EventArgs e)
        {
            if(currentState == 2)
            {
                double result = 0;
                if(mathOperator == "+")
                {
                    result = firtNumber + secondNumber;
                }
                if (mathOperator == "-")
                {
                    result = firtNumber - secondNumber;
                }

                if (mathOperator == "X")
                {
                    result = firtNumber * secondNumber;
                }
                if (mathOperator == "/")
                {
                    result = firtNumber / secondNumber;
                }

                this.resultText.Text = result.ToString();
                //this.resultText.Text = result.ToString("N0");
                firtNumber = result;
                currentState = -1;
            }
        }
        }
    }

