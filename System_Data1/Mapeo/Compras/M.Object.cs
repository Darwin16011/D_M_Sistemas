using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.Compras;
using D_M_Sistemas.Entidades.Almacen;

using D_M_Sistemas.Entidades.Users;

using D_M_Sistemas.Entidades.Ventas;


namespace D_M_Sistemas.Datos.Mapeo.Compras
{
    public class ObjectsMap : IEntityTypeConfiguration<Objects>
    {
        public void Configure(EntityTypeBuilder<Objects> builder)
        {
            builder.ToTable("Objects")
                .HasKey(c => c.idObjects);
            builder.Property(c => c.cantidad);
            builder.Property(c => c.precioObjects);
            //fk de ingreso
            builder.HasOne(y => y.Ingresos)
                .WithOne();
            //fk de articulo
            builder.HasOne(y => y.Articulos)
                .WithOne();
        }
    }
}