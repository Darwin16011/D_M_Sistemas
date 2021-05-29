using Systeusing System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using D_M_Sistemas.Entidades.Compras;

namespace D_M_Sistemas.Entidades.Almacen
{
    public class Objects
    {


        public int idObjects { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public string codigoObjects { get; set; }
        [StringLength(50)]
        public string nombreObjects { get; set; }
        [StringLength(50)]
        public decimal precioVenta { get; set; }
        public int stock { get; set; }
        public string descripcionObjects { get; set; }
        [StringLength(256)]
        public bool condicion { get; set; }
        //ESTA ES LA RELACION CON LA TABLA CATEGORIAS PARA HACER LA FK
        public List<Categoria> Categorias { get; set; }


    }
}
