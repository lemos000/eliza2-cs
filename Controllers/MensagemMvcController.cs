using Microsoft.AspNetCore.Mvc;
using eliza2_api.Services;
using eliza2_api.Model.Entity;
using eliza2_api.Model.DTO;

namespace eliza2_api.Controllers
{
    [IgnoreAntiforgeryToken]
    public class MensagemMvcController : Controller
    {
        private readonly MensagemService _service;

        public MensagemMvcController(MensagemService service)
        {
            _service = service;
        }

        // GET: /MensagemMvc
        public async Task<IActionResult> Index()
        {
            var mensagens = await _service.GetAllAsync();
            return View(mensagens);
        }

        // GET: /MensagemMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /MensagemMvc/Create
        [HttpPost]
        public async Task<IActionResult> Create(MensagemRequestDTO dto)
        {
            if (ModelState.IsValid)
            {
                int usuarioId = dto.Id;
                await _service.EnviarMensagemAsync(usuarioId, dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: /MensagemMvc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var mensagem = await _service.getMensagem(id);
            if (mensagem == null) return NotFound();

            var dto = new MensagemRequestDTO { Texto = mensagem.TextoUsuario };
            ViewBag.Id = id;
            ViewBag.UsuarioId = mensagem.UsuarioId;
            return View(dto);
        }

        // POST: /MensagemMvc/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, int usuarioId, MensagemRequestDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateMensagemAsync(usuarioId, id, dto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Id = id;
            ViewBag.UsuarioId = usuarioId;
            return View(dto);
        }

        // GET: /MensagemMvc/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var mensagem = await _service.getMensagem(id);
            if (mensagem == null) return NotFound();
            return View(mensagem);
        }

        // POST: /MensagemMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagem = await _service.getMensagem(id);
            if (mensagem != null)
                await _service.DeleteMensagemAsync(mensagem.UsuarioId, id);

            return RedirectToAction(nameof(Index));
        }
    }
}
