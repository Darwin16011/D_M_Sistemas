﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using D_M_Sistemas.Entidades.Users;

namespace D_M_Sistemas.Entidades.Ventas
{
    public class Ventas
    {
        public int idVentas { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ERROR")]

        public string tipoComprobante { get; set; }
        [StringLength(20)]
        public string serieComprobante { get; set; }
        [StringLength(7)]
        public string numComprobante { get; set; }
        [StringLength(10)]
        public DateTime fechaHora { get; set; }

        public decimal impuesto { get; set; }

        public decimal total { get; set; }

        public string estado { get; set; }

        public List<Persons> Persons { get; set; }
        public List<Users> Users { get; set; }

    }
}

