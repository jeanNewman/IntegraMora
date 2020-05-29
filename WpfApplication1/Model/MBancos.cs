using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    class MBancos
    {
        public MBancos(string account, string operacion, string tipo, decimal debe, decimal haber)
        {
            Cuenta = account;
            Operacion= operacion;
            Tipo = tipo;
            VentaDebe = debe;
            VentaHaber = haber;
          
            
        }

        public string Cuenta { get; set; }
        public string Operacion { get; set; }
        public string Tipo { get; set; }
        public decimal VentaDebe { get; set; }
        public decimal VentaHaber { get; set; }

    }
}
