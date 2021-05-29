using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using D_M_Sistemas.Entidades.Compras;
using D_M_Sistemas.Entidades.Almacen;

namespace D_M_Sistemas.Entidades.Sales
{
    public class Venta_Detail
    {
        public int idVenta_Detail { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ERROR")]

        public string cantidad { get; set; }
        [StringLength(50)]
        public decimal PrecioVenta_Detail { get; set; }

        public decimal descuentoVenta_Detail { get; set; }
        //FK PARA TBL VENTAS Y ARTICULOS
        public List<Ventas> Ventas { get; set; }
        public List<Objects> Objects { get; set; }

    }
}