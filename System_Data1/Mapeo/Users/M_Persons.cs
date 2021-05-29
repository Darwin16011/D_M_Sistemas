using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D_M_Sistemas.Entidades.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_M_Sistemas.Datos.Mapeo.User
{
    public class PersonMap : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            builder.ToTable("Persons")
                .HasKey(f => f.idPersons);
            builder.Property(f => f.tipoPersons)
                .HasMaxLength(20);
            builder.Property(f => f.primerNombre)
                .HasMaxLength(100);
            builder.Property(f => f.segundoNombre)
                .HasMaxLength(100);
            builder.Property(f => f.tercerNombre)
                .HasMaxLength(100);
            builder.Property(f => f.primerApellido)
                .HasMaxLength(100);
            builder.Property(f => f.segundoApellido)
                .HasMaxLength(100);
            builder.Property(f => f.tercerApellido)
                .HasMaxLength(100);
            builder.Property(f => f.tipoDocumento)
                .HasMaxLength(50);
            builder.Property(f => f.numDocumento)
                .HasMaxLength(70);
            builder.Property(f => f.telefonoPersons)
                .HasMaxLength(20);
            builder.Property(f => f.email)
                .HasMaxLength(50);

        }
    }
}