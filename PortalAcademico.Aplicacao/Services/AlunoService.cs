using PortalAcademico.Aplicacao.Interfaces;
using PortalAcademico.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalAcademico.Infra.Context;
using PortalAcademico.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace PortalAcademico.Aplicacao.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AlunoDbContext _context;

        public AlunoService(AlunoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlunoViewModel>> ListarAsync()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return alunos.Select(a => new AlunoViewModel
            {
                Id = a.Id,
                Nome = a.Nome,
                Email = a.Email,
                DataNascimento = a.DataNascimento
            });
        }

        public async Task<AlunoViewModel> ObterPorIdAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return null;

            return new AlunoViewModel
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Email = aluno.Email,
                DataNascimento = aluno.DataNascimento
            };
        }

        public async Task CriarAsync(AlunoViewModel viewModel)
        {
            var aluno = new Aluno(viewModel.Nome, viewModel.Email, viewModel.DataNascimento);
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(AlunoViewModel viewModel)
        {
            var aluno = await _context.Alunos.FindAsync(viewModel.Id);
            if (aluno == null) return;

            aluno.Nome = viewModel.Nome;
            aluno.Email = viewModel.Email;
            aluno.DataNascimento = viewModel.DataNascimento;

            await _context.SaveChangesAsync();
        }


        public async Task ExcluirAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return;

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
