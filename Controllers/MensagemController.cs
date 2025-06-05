namespace eliza2_api.Controllers
{
  
    using global::eliza2_api.Model.DTO;
    using Microsoft.AspNetCore.Mvc;

    namespace eliza2_api.Controllers
    {
        [ApiController]
        [Route("api/mensagem")]
        public class MensagemController : ControllerBase
        {
            private readonly MensagemService _mensagemService;

            public MensagemController(MensagemService mensagemService)
            {
                _mensagemService = mensagemService;
            }

            [HttpPost("enviar/{usuarioId}")]
            public async Task<IActionResult> Enviar(int usuarioId, [FromBody] MensagemRequestDTO dto)
            {
                try
                {
                    var mensagem = await _mensagemService.EnviarMensagemAsync(usuarioId, dto);
                    return Ok(new
                    {
                        mensagem.Id,
                        mensagem.TextoUsuario,
                        mensagem.RespostaBot,
                        mensagem.DataHora
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro: " +  new { message = ex.Message });
                }
            }

            [HttpGet("historico/{usuarioId}")]
            public async Task<IActionResult> Historico(int usuarioId)
            {
                var mensagens = await _mensagemService.GetHistoricoAsync(usuarioId);
                var result = mensagens.Select(m => new
                {
                    m.Id,
                    m.TextoUsuario,
                    m.RespostaBot,
                    m.DataHora
                });
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetMensagem(int id)
            {
                try
                {
                    var mensagem = await _mensagemService.getMensagem(id);
                    return Ok(new
                    {
                        mensagem.Id,
                        mensagem.TextoUsuario,
                        mensagem.RespostaBot,
                        mensagem.DataHora
                    });
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(new { message = ex.Message });
                }
            }

            [HttpPut("{usuarioId}/update/{mensagemId}")]
            public async Task<IActionResult> Update(int usuarioId, int mensagemId, [FromBody] MensagemRequestDTO dto)
            {
                var atualizado = await _mensagemService.UpdateMensagemAsync(usuarioId, mensagemId, dto);
                if (!atualizado)
                    return NotFound(new { message = "Mensagem não encontrada ou não pertence ao usuário." });

                return Ok(new { message = "Mensagem atualizada com sucesso." });
            }

            [HttpDelete("{usuarioId}/delete/{mensagemId}")]
            public async Task<IActionResult> Delete(int usuarioId, int mensagemId)
            {
                var deletado = await _mensagemService.DeleteMensagemAsync(usuarioId, mensagemId);
                if (!deletado)
                    return NotFound(new { message = "Mensagem não encontrada ou não pertence ao usuário." });

                return Ok(new { message = "Mensagem deletada com sucesso." });
            }
        }
    }

}
