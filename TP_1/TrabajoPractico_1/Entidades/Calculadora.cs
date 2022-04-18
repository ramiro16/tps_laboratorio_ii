using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';

            switch(operador)
            {
                case '+':
                    retorno = '+';
                    break;
                case '-':
                    retorno = '-';
                    break;
                case '*':
                    retorno = '*';
                    break;
                case '/':
                    retorno = '/';
                    break;
                default:
                    retorno = '+';
                    break;
            }

            return retorno;
        }

        public static double Operar(Operando num1, Operando num2, char operacion)
        {
            char auxiliar = ValidarOperador(operacion);
            double retorno = 0;

            switch (auxiliar)
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
            }

            return retorno;
        }
    }
}
