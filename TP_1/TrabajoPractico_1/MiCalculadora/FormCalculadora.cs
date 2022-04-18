using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "Resultado";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            char simbolo = Convert.ToChar(operador);
            double respuesta = Calculadora.Operar(num1, num2, simbolo);

            return respuesta;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = resultado.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append($"{txtNumero1.Text} {cmbOperador.SelectedItem.ToString()} {txtNumero2.Text} = {resultado.ToString()}");

            lstOperaciones.Items.Add(sb.ToString());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string auxCadena = lblResultado.Text;

            if (auxCadena != "Resultado")
            {
                Operando operando = new Operando(auxCadena);

                auxCadena = operando.BinarioDecimal(auxCadena);

                lblResultado.Text = auxCadena;
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string auxCadena = lblResultado.Text;

            if (auxCadena != "Resultado")
            {
                Operando operando = new Operando(auxCadena);

                auxCadena = operando.DecimalBinario(auxCadena);

                lblResultado.Text = auxCadena;
            }
        }
    }
}
