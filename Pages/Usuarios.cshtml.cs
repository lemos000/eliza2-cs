using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eliza2_api.Services;
using eliza2_api.Model.Entity;
using eliza2_api.Model.DTO;
using System.Collections.Generic;

public class UsuariosModel : PageModel
{
    private readonly UsuarioService _service;
    public List<Usuario> Usuarios { get; set; }
    [BindProperty]
    public Usuario Input { get; set; } = new Usuario();
    public string Msg { get; set; }

    public UsuariosModel(UsuarioService service)
    {
        _service = service;
    }

    public async Task OnGetAsync()
    {
        Usuarios = await _service.GetAllAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Input.Id == 0)
        {
            await _service.RegisterAsync(new UsuarioRegisterDTO
            {
                Nome = Input.Nome,
                Email = Input.Email,
                Senha = Input.SenhaHash
            });
            Msg = "Usuário cadastrado!";
        }
        else
        {
           
            await _service.UpdateAsync(Input.Id, new UsuarioRegisterDTO
            {
                Nome = Input.Nome,
                Email = Input.Email,
                Senha = Input.SenhaHash
            });
            Msg = "Usuário atualizado!";
        }
        return RedirectToPage("/");
    }

    public async Task<IActionResult> OnPostEditAsync(int id)
    {
        var u = await _service.GetByIdAsync(id);
        if (u != null)
        {
            Input = u;
            Usuarios = await _service.GetAllAsync();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToPage("/");
    }
}
