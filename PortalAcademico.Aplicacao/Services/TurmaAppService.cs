using Mapster;
using MapsterMapper;
using PortalAcademico.Aplicacao.Interfaces;
using PortalAcademico.Aplicacao.ViewModels;
using PortalAcademico.Dominio.Entidades;
using PortalAcademico.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Aplicacao.Services
{
    // Application/Services/TurmaAppService.cs
    public class TurmaAppService : ITurmaAppService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaAppService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<List<TurmaViewModel>> ObterTodosAsync()
        {
            var turmas = await _turmaRepository.GetAllAsync();
            return turmas.Adapt<List<TurmaViewModel>>();
        }

        public async Task<TurmaViewModel?> ObterPorIdAsync(int id)
        {
            var turma = await _turmaRepository.GetByIdAsync(id);
            return turma?.Adapt<TurmaViewModel>();
        }

        public async Task CriarAsync(TurmaViewModel viewModel)
        {
            var entity = viewModel.Adapt<Turma>();
            await _turmaRepository.AddAsync(entity);
            await _turmaRepository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(TurmaViewModel viewModel)
        {
            var entity = viewModel.Adapt<Turma>();
            _turmaRepository.Update(entity);
            await _turmaRepository.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var entity = await _turmaRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _turmaRepository.Remove(entity);
                await _turmaRepository.SaveChangesAsync();
            }
        }
    }

}
