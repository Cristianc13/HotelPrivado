using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPrivado.Models
{
    public class Cliente
    {

        [Key]
        public int idCliente { get; set; }

        public string nombre { get; set; }
        public string documento { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }
        public string lugarNacimiento { get; set; }
        public string sexo { get; set; }
        public string observacion { get; set; }


    }
}
