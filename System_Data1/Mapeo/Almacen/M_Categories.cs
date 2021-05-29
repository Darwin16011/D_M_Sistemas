using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.Compras;
using D_M_Sistemas.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Text;



namespace D_M_Sistemas.Datos.Mapeo.Almacen
{
    public class CategoriesMap : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories")
                .HasKey(a => a.idcategories);
            builder.Property(a => a.nombre)
            .HasMaxLength(50);
            builder.Property(a => a.descripcion)
                .HasMaxLength(256);

            builder.Property(b => b.condicion);
            //RELACION CON CATEGORIES 1 A 1 


        }
    }
}
