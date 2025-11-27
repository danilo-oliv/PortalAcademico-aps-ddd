using PortalAcademico.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Aplicacao.Interfaces
{
    public interface ITurmaAppService
    {
        Task<List<TurmaViewModel>> ObterTodosAsync();
        Task<TurmaViewModel?> ObterPorIdAsync(int id);
        Task CriarAsync(TurmaViewModel viewModel);
        Task AtualizarAsync(TurmaViewModel viewModel);
        Task ExcluirAsync(int id);
    }

}
