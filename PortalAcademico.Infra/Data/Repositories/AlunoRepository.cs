using Microsoft.EntityFrameworkCore;
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
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(PortalAcademicoDbContext context) : base(context) { }

        public async Task<List<Aluno>> GetAllWithTurmaAsync()
        {
            return await _context.Alunos
                .Include(a => a.Turma)
                .ToListAsync();
        }
    }

}
