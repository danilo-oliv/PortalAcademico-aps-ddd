using Mapster;
using Microsoft.EntityFrameworkCore;
using PortalAcademico.Aplicacao.Interfaces;
using PortalAcademico.Aplicacao.ViewModels;
using PortalAcademico.Dominio.Entidades;
using PortalAcademico.Dominio.Interfaces;

namespace PortalAcademico.Aplicacao.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;

        public AlunoAppService(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository)
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
        }

        public async Task<List<AlunoViewModel>> ObterTodosAsync()
        {
            var alunos = await _alunoRepository.GetAllWithTurmaAsync();
            return alunos.Adapt<List<AlunoViewModel>>();
        }

        public async Task<AlunoViewModel?> ObterPorIdAsync(int id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);
            return aluno?.Adapt<AlunoViewModel>();
        }

        public async Task CriarAsync(AlunoViewModel viewModel)
        {
            var entity = viewModel.Adapt<Aluno>();
            await _alunoRepository.AddAsync(entity);
            await _alunoRepository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(AlunoViewModel viewModel)
        {
            var entity = viewModel.Adapt<Aluno>();
            _alunoRepository.Update(entity);
            await _alunoRepository.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var entity = await _alunoRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _alunoRepository.Remove(entity);
                await _alunoRepository.SaveChangesAsync();
            }
        }
    }
}
