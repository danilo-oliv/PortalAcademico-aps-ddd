using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PortalAcademico.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Infra.Factory
{
    public class PortalDbContextFactory : IDesignTimeDbContextFactory<AlunoDbContext>
    {
        public AlunoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AlunoDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PortalAcademicoDB;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=False;");
            return new AlunoDbContext(optionsBuilder.Options);
        }
    }
}
