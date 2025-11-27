using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalAcademico.Dominio.Entidades;
using PortalAcademico.Infra.Configuration;
namespace PortalAcademico.Infra.Context
{
    public class PortalAcademicoDbContext : DbContext
    {
        public PortalAcademicoDbContext(DbContextOptions<PortalAcademicoDbContext> options)
            : base(options) { }

        public DbSet<Aluno> Alunos { get; set; } = null!;
        public DbSet<Turma> Turmas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new TurmaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
