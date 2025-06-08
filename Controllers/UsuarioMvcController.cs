using Microsoft.AspNetCore.Mvc;
using eliza2_api.Services;
using eliza2_api.Model.Entity;
using eliza2_api.Model.DTO;

namespace eliza2_api.Controllers
{

    [IgnoreAntiforgeryToken]
    public class UsuarioMvcController : Controller
    {
        private readonly UsuarioService _service;

        public UsuarioMvcController(UsuarioService service)
        {
            _service = service;
        }

        // GET: /UsuarioMvc
        public async Task<IActionResult> Index()
        {
            var usuarios = await _service.GetAllAsync();
            return View(usuarios);
        }

        // GET: /UsuarioMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /UsuarioMvc/Create
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioRegisterDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Senha))
                throw new Exception("Senha não pode ser vazia!");
            if (ModelState.IsValid)
            {
                await _service.RegisterAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: /UsuarioMvc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var dto = new UsuarioRegisterDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = "" // Não exibe senha
            };
            ViewBag.Id = id;
            return View(dto);
        }

        // POST: /UsuarioMvc/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UsuarioRegisterDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Id = id;
            return View(dto);
        }

        // GET: /UsuarioMvc/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // POST: /UsuarioMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
