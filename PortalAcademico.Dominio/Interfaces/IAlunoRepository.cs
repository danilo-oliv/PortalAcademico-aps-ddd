using PortalAcademico.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Dominio.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<Aluno?> GetByIdAsync(int id);
        Task<Aluno> AddAsync(Aluno aluno);
        Task<Aluno> UpdateAsync(Aluno aluno);
        Task DeleteAsync(int id);
    }
}
