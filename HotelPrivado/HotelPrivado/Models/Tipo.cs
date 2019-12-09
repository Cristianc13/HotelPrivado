using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPrivado.Models
{
    public class Tipo
    {
        [Key]
        public int idTipo { get; set; }
        public string Nombre { get; set; }
    }
}
