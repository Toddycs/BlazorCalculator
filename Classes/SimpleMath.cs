using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCalculator.Classes
{
    public class SimpleMath
    {
        // Primeiro valor a ser colocado na calculadora
        public string? FirstValue { get; set; } = "";

        // Operador de calculo (+,-,*,/)
        public string? Operator { get; set; }

        // Segundo valor a ser colocado na calculadora
        public string? SecondValue { get; set; } = "";

        // Resultado
        public string? Result { get; set; } = "";

        public string Calc { get; set; }
    }
}
