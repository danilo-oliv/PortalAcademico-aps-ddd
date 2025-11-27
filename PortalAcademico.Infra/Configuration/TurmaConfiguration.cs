using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalAcademico.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Infra.Configuration
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turmas");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Ano)
                   .IsRequired();

            builder.HasMany(t => t.Alunos)
                   .WithOne(a => a.Turma)
                   .HasForeignKey(a => a.TurmaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
