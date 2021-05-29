using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace D_M_Sistemas.Entidades.Users
{
    public class Rols
    {
        public int idRols { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "DATO INCORRECTO")]
        public string nombreRols { get; set; }
        [StringLength(50)]
        public string descripcionRols { get; set; }
        [StringLength(100)]
        public bool condicion { get; set; }
    }
}
