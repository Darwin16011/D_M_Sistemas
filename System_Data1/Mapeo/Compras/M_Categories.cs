using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.Compras;


namespace D_M_Sistemas.Datos.Mapeo.Compras
{
    public class CategoriesMap : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories")
            .HasKey(e => e.idCategories);
            builder.Property(e => e.tipoComprobante)
                .HasMaxLength(20);
            builder.Property(e => e.serieComprobante)
                .HasMaxLength(7);
            builder.Property(e => e.numComprobante)
                .HasMaxLength(10);
            builder.Property(e => e.fechaHora);
            builder.Property(e => e.impuesto);
            builder.Property(e => e.total);
            builder.Property(e => e.estado);

            //relaciones 
            builder.HasOne(w => w.Usuarios)
                .WithOne();
            builder.HasOne(w => w.Persons)
                .WithOne();


        }
    }
}