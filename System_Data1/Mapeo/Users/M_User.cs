using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_M_Sistemas.Datos.Mapeo.User
{
    public classUserMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
                 .HasKey(h => h.idUser);
            builder.Property(h => h.nombreUser)
                .HasMaxLength(100);
            builder.Property(h => h.tipoDocumento)
                .HasMaxLength(20);
            builder.Property(h => h.numDocumento)
                .HasMaxLength(20);
            builder.Property(h => h.direccion)
                .HasMaxLength(70);
            builder.Property(h => h.telefono)
                .HasMaxLength(20);
            builder.Property(h => h.email)
                .HasMaxLength(50);
            builder.Property(h => h.password_hash);
            builder.Property(h => h.password_sal);
            builder.Property(h => h.condicion);
            //relaciones
            builder.HasOne(v => v.Roles)
                .WithOne();

        }
    }
}
