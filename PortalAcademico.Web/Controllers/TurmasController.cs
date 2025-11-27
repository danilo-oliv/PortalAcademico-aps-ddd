using Microsoft.AspNetCore.Mvc;
using PortalAcademico.Aplicacao.Interfaces;
using PortalAcademico.Aplicacao.ViewModels;

namespace PortalAcademico.Web.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ITurmaAppService _turmaAppService;

        public TurmasController(ITurmaAppService turmaAppService)
        {
            _turmaAppService = turmaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var turmas = await _turmaAppService.ObterTodosAsync();
            return View(turmas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TurmaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            await _turmaAppService.CriarAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var turma = await _turmaAppService.ObterPorIdAsync(id);
            if (turma == null) return NotFound();
            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TurmaViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(viewModel);

            await _turmaAppService.AtualizarAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var turma = await _turmaAppService.ObterPorIdAsync(id);
            if (turma == null) return NotFound();
            return View(turma);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var turma = await _turmaAppService.ObterPorIdAsync(id);
            if (turma == null) return NotFound();
            return View(turma);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _turmaAppService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
