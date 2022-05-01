using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA : {this.marca}");
            sb.AppendLine($"COLOR : {this.color}");
            sb.AppendLine("---------------------");

            sb.AppendLine($"TAMANO : {this.Tamanio}");

            return sb.ToString();
        }
    }
}
