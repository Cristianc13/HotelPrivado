using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HotelPrivado.Models
{
    public class Alquiler
    {
        [Key]
        public int idAlquiler { get; set; }
        public double Precio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEnt { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaSal { get; set; }
        public string Observacion { get; set; }

        //LLave foranea para Vendedor
        [ForeignKey("Vendedor")]
        public int idVendedor { get; set; }
        [ForeignKey("idVendedor")]
        public virtual Vendedor Vendedor { get; set; }

        //LLave foranea para Cliente
        [ForeignKey("Cliente")]
        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public virtual Cliente Cliente { get; set; }

        //LLave foranea para Habitacion
        [ForeignKey("Habitacion")]
        public int idHabitacion { get; set; }
        [ForeignKey("idHabitacion")]
        public virtual Habitacion Habitacion { get; set; }
    }
}
