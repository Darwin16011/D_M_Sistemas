using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.Compras;
using D_M_Sistemas.Entidades.Almacen;

namespace D_M_Sistemas.Datos.Mapeo.Almacen
{
    public class ObjectsMap : IEntityTypeConfiguration<Objects>
    {
        public void Configure(EntityTypeBuilder<Objects> builder)
        {
            builder.ToTable("objects")
                .HasKey(b => b.idObjects);
            builder.Property(b => b.codigoObjects)
              .HasMaxLength(50);
            builder.Property(b => b.nombreObjects)
                .HasMaxLength(50);
            builder.Property(b => b.precioVenta);
            builder.Property(b => b.stock);
            builder.Property(b => b.descripcionObjects)
                .HasMaxLength(256);
            builder.Property(b => b.condicion);
            //RELACION CON CATEGORIA 1 A 1 
            builder.HasOne(z => z.Categories)
                .WithOne();



        }
    }
}
