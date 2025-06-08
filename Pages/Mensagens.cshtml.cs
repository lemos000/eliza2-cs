using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eliza2_api.Services;
using eliza2_api.Model.Entity;

public class MensagensModel : PageModel
{
    private readonly MensagemService _service;
    public List<Mensagem> Mensagens { get; set; }
    [BindProperty]
    public Mensagem Input { get; set; } = new Mensagem();
    public string Msg { get; set; }

    public MensagensModel(MensagemService service)
    {
        _service = service;
    }


    public async Task OnGetAsync()
    {
        Mensagens = await _service.GetAllAsync(); // Faça um método que retorna todas as mensagens
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Input.Id == 0)
        {
            // NOVA mensagem
            await _service.EnviarMensagemAsync(Input.UsuarioId, new()
            {
                Texto = Input.TextoUsuario
            });
            Msg = "Mensagem enviada!";
        }
        else
        {
            // EDITAR mensagem
            await _service.UpdateMensagemAsync(Input.UsuarioId, Input.Id, new()
            {
                Texto = Input.TextoUsuario
            });
            Msg = "Mensagem atualizada!";
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostEditAsync(int id)
    {
        var m = await _service.getMensagem(id);
        if (m != null)
        {
            Input = m;
            Mensagens = await _service.GetAllAsync();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var m = await _service.getMensagem(id);
        if (m != null)
            await _service.DeleteMensagemAsync(m.UsuarioId, id);

        return RedirectToPage();
    }
}
