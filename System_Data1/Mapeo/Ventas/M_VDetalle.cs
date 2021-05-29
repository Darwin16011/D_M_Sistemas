using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
usingD_M_Sistemas.Entidades.Ventas;
namespaceD_M_Sistemas.Datos.Mapeo.Ventas
{
    public class DetalleVentaMap : IEntityTypeConfiguration<DetalleVentas>
    {
        public void Configure(EntityTypeBuilder<DetalleVentas> builder)
        {
            builder.ToTable("detalleVentas")
                 .HasKey(d => d.idDetalleVentas);
            builder.Property(d => d.cantidad);
            builder.Property(d => d.PrecioDetalleVentas);
            builder.Property(d => d.descuentoDetalleVentas);
            //relaciones fk
            builder.HasOne(x => x.Ventas)
                .WithOne();
            builder.HasOne(x => x.Articulos)
                .WithOne();
        }
    }
}
