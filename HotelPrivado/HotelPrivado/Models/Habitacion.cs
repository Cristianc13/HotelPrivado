using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPrivado.Models
{
    public class Habitacion
    {
        [Key]
        public int idHabitacion { get; set; }
        public int NumeroCamas { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Observacion { get; set; }

        [ForeignKey("Tipo")]
        public int idTipo { get; set; }
        [ForeignKey("idTipo")]
        public virtual Tipo Tipo { get; set; }
    }
}
