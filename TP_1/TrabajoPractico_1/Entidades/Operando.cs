using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string numero)
            : this(Convert.ToDouble(numero))
        {

        }

        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        private double ValidarOperando(string strNumero)
        {
            double retorno;
            _ = double.TryParse(strNumero, out retorno);

            return retorno;
        }


        private bool EsBinario(string binario)
        {
            bool retorno = false;
            char[] bin = binario.ToArray<char>();

            for (int i = 0; i < bin.Length; i++)
            {
                char aux = bin[i];
                if (bin[i] != '1' && bin[i] != '0')
                {
                    retorno = false;
                    break;
                }

                retorno = true;
            }

            return retorno;
        }

        public string BinarioDecimal(string binario)
        {
            string retorno;
            int auxRetorno = 0;

            if (EsBinario(binario))
            {
                int lenghtBinario = binario.Length;

                foreach (char item in binario)
                {
                    lenghtBinario--;
                    if (item == '1')
                    {
                        auxRetorno += (int)Math.Pow(2, lenghtBinario);
                    }
                }

                retorno = auxRetorno.ToString();
            }

            else
            {
                retorno = "Valor inválido";
            }

            return retorno;
        }

        public string DecimalBinario(double numero)
        {
            string retorno = "Valor inválido";
            double auxNumero = Math.Abs(numero);

            int resultadoDivision = (int)auxNumero;
            int restoDivision;

            if (resultadoDivision >= 0)
            {
                retorno = "";
                do
                {
                    restoDivision = resultadoDivision % 2;
                    resultadoDivision /= 2;
                    retorno = restoDivision.ToString() + retorno;
                } while (resultadoDivision > 0);
            }

            return retorno;
        }

        public string DecimalBinario(string numero)
        {
            double numConver = Convert.ToDouble(numero);

            return DecimalBinario(numConver);
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
                
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}
