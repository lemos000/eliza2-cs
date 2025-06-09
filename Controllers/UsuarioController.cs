namespace eliza2_api.Controllers
{
    using global::eliza2_api.Model.DTO;
    using global::eliza2_api.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace eliza2_api.Controllers
    {
        [ApiController]
        [Route("api/usuario")]
        public class UsuarioController : ControllerBase
        {
            private readonly UsuarioService _usuarioService;

            public UsuarioController(UsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] UsuarioRegisterDTO dto)
            {
                try
                {
                    var usuario = await _usuarioService.RegisterAsync(dto);
                    return Created("", usuario);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO dto)
            {
                try
                {
                    var usuario = await _usuarioService.LoginAsync(dto);
                    return Ok("Usuario logado com sucesso: \n" + usuario.Nome + "\nid: " + usuario.Id);
                }
                catch (Exception ex)
                {
                    return Unauthorized(new { message = ex.Message });
                }
            }

            [HttpGet("profile/{id}")]
            public async Task<IActionResult> Profile(int id)
            {
                var usuario = await _usuarioService.GetProfileAsync(id);
                if (usuario == null) return NotFound(new { message = "Usuário não encontrado." });
                return Ok(usuario);
            }
        }
    }

}
