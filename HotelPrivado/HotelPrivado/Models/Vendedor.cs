using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPrivado.Models
{
    public class Vendedor
    {
        [Key]
        public int idVendedor { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string observacion { get; set; }
        public double sueldo { get; set; }




    }
}
