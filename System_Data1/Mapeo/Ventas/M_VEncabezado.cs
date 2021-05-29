using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.Ventas;
namespace D_M_Sistemas.Datos.Mapeo.Ventas
{
    public class VentaMap : IEntityTypeConfiguration<Ventas>
    {
        public void Configure(EntityTypeBuilder<Ventas> builder)
        {
            builder.ToTable("Ventas")
                 .HasKey(i => i.idVentas);
            builder.Property(i => i.tipoComprobante)
            .HasMaxLength(20);
            builder.Property(i => i.serieComprobante)
                .HasMaxLength(7);
            builder.Property(i => i.numComprobante)
                .HasMaxLength(10);
            builder.Property(i => i.fechaHora);
            builder.Property(i => i.impuesto);
            builder.Property(i => i.total);
            builder.Property(i => i.estado)
                .HasMaxLength(20);

            //RELACIONES
            builder.HasOne(U => U.Persons)
                .WithOne();
            builder.HasOne(u => u.Users)
                .WithOne();
        }
    }
}
