using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_M_Sistemas.Datos.Mapeo.User
{
    public class RolesMap : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles")
                .HasKey(g => g.idRoles);
            builder.Property(g => g.nombreRoles)
                 .HasMaxLength(50);
            builder.Property(g => g.descripcionRoles)
                .HasMaxLength(100);
            builder.Property(g => g.condicion);

        }
    }
}
