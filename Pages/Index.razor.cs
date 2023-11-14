using BlazorCalculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCalculator.Pages
{
    public partial class Index
    {
        public SimpleMath SimpleMath = new SimpleMath();
        public string Position = "FIRST";


        public void Update(char _V)
        {
            string value = _V.ToString();
            if(Position == "FIRST")
            {
                SimpleMath.FirstValue += value;
                SimpleMath.Calc = SimpleMath.FirstValue.ToString();
            }
            else if(Position == "SECOND")
            {
                SimpleMath.SecondValue += value;
                SimpleMath.Calc = SimpleMath.FirstValue.ToString() + SimpleMath.Operator + SimpleMath.SecondValue.ToString();
            }
        }


        public void SetOperator(char _op)
        {
            string op = _op.ToString();
            if(!string.IsNullOrEmpty(op))
            {
                if(Position == "FIRST")
                {
                    SimpleMath.Operator = op;
                    Position = "SECOND";
                }
            }
        }

        public void Calculate()
        {
            if (SimpleMath.FirstValue != null && SimpleMath.Operator != null && SimpleMath.SecondValue != null)
            {
                double firstNumber;
                double secondNumber;

                if (double.TryParse(SimpleMath.FirstValue, out firstNumber) && double.TryParse(SimpleMath.SecondValue, out secondNumber))
                {
                    switch (SimpleMath.Operator)
                    {
                        case "+":
                            SimpleMath.Result = (firstNumber + secondNumber).ToString();
                            break;

                        case "-":
                            SimpleMath.Result = (firstNumber - secondNumber).ToString();
                            break;

                        case "*":
                            SimpleMath.Result = (firstNumber * secondNumber).ToString();
                            break;

                        case "/":
                            if (secondNumber != 0)
                            {
                                SimpleMath.Result = (firstNumber / secondNumber).ToString();
                            }
                            else
                            {
                                // Lógica para lidar com a divisão por zero, se necessário
                            }
                            break;
                    }

                    SimpleMath.SecondValue = null;
                    SimpleMath.Operator = null;
                    Position = "FIRST";
                }
                else
                {
                    SimpleMath.Calc = "Erro, tente novamente.";
                }
            }
        }

        public void Clear()
        {
            Position = "FIRST";
            SimpleMath = new SimpleMath();
            StateHasChanged();
        }
    }
}
