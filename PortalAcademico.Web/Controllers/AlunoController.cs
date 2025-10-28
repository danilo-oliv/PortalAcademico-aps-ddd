using Microsoft.AspNetCore.Mvc;
using PortalAcademico.Aplicacao.Interfaces;
using PortalAcademico.Aplicacao.ViewModels;

namespace PortalAcademico.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var alunos = await _service.ListarAsync();
            return View(alunos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _service.ObterPorIdAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        public IActionResult Create()
        {
            return View(new AlunoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlunoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CriarAsync(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _service.ObterPorIdAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AlunoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.AtualizarAsync(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _service.ObterPorIdAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.ExcluirAsync(id);
            return RedirectToAction("Index");
        }
    }
}
