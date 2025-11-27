using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalAcademico.Aplicacao.Interfaces;
using PortalAcademico.Aplicacao.ViewModels;

namespace PortalAcademico.Web.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoAppService _alunoAppService;
        private readonly ITurmaAppService _turmaAppService;

        public AlunosController(IAlunoAppService alunoAppService, ITurmaAppService turmaAppService)
        {
            _alunoAppService = alunoAppService;
            _turmaAppService = turmaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var alunos = await _alunoAppService.ObterTodosAsync();
            return View(alunos);
        }

        public async Task<IActionResult> Create()
        {
            await PopularTurmasDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularTurmasDropDownList(viewModel.TurmaId);
                return View(viewModel);
            }

            await _alunoAppService.CriarAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _alunoAppService.ObterPorIdAsync(id);
            if (aluno == null) return NotFound();

            await PopularTurmasDropDownList(aluno.TurmaId);
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlunoViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopularTurmasDropDownList(viewModel.TurmaId);
                return View(viewModel);
            }

            await _alunoAppService.AtualizarAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _alunoAppService.ObterPorIdAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _alunoAppService.ObterPorIdAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _alunoAppService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopularTurmasDropDownList(object? selected = null)
        {
            var turmas = await _turmaAppService.ObterTodosAsync();
            ViewBag.TurmaId = new SelectList(turmas, "Id", "Nome", selected);
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return PartialView("_ListaAlunosParcial", new List<AlunoViewModel>());

            var alunos = await _alunoAppService.ObterTodosAsync();
            var resultado = alunos.Where(a => a.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)).ToList();

            return PartialView("_ListaAlunosParcial", resultado);
        }

    }

}
