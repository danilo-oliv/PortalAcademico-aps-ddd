using PortalAcademico.Dominio.Entidades;
using PortalAcademico.Dominio.Interfaces;
using PortalAcademico.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Infra.Data.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(PortalAcademicoDbContext context) : base(context) { }
    }

}
