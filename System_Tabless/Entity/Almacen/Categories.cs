using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace D_M_Sistemas.Entidades.Almacen
{
    public class Categories
    {
        public int idCategories { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }

        public bool condicion { get; set; }
        List<Articulo> Articulos { get; set; }
    }
}
