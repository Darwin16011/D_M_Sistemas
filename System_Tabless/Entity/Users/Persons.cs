using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace D_M_Sistemas.Entidades.Users
{
    public class Persons
    {
        public int idPersons { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ERROR DATOS")]
        public string tipoPersons { get; set; }
        [StringLength(20)]
        public string primerNombre { get; set; }
        [StringLength(100)]
        public string segundoNombre { get; set; }
        [StringLength(100)]
        public string tercerNombre { get; set; }
        [StringLength(100)]
        public string primerApellido { get; set; }
        [StringLength(100)]
        public string segundoApellido { get; set; }
        [StringLength(100)]
        public string tercerApellido { get; set; }
        [StringLength(100)]
        public string tipoDocumento { get; set; }
        [StringLength(50)]
        public string numDocumento { get; set; }
        [StringLength(70)]
        public string telefonoPersons { get; set; }
        [StringLength(20)]
        public string email { get; set; }
    }
}
