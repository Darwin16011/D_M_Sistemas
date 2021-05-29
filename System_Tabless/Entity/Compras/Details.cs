using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using D_M_Sistemas.Entidades.Almacen;

namespace D_M_Sistemas.Entidades.Compras
{
    public class Details
    {
        public int idDetails { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public int cantidad { get; set; }

        public decimal precioDetails { get; set; }

        public List<Ingreso> Ingresos { get; set; }
        public List<Articulo> Articulos { get; set; }
    }
}
