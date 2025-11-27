using PortalAcademico.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Aplicacao.Interfaces
{
    public interface IAlunoAppService
    {
        Task<List<AlunoViewModel>> ObterTodosAsync();
        Task<AlunoViewModel?> ObterPorIdAsync(int id);
        Task CriarAsync(AlunoViewModel viewModel);
        Task AtualizarAsync(AlunoViewModel viewModel);
        Task ExcluirAsync(int id);
    }

}
