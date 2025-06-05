using eliza2_api.Data;
using eliza2_api.Model.DTO;
using eliza2_api.Model.Entity;
using eliza2_api.Services;
using Microsoft.EntityFrameworkCore;

public class MensagemService
{
    private readonly AppDbContext _context;
    private GeminiService _gemini;

    public MensagemService(AppDbContext context, GeminiService gemini)
    {
        _context = context;
        _gemini = gemini;
    }

    public async Task<Mensagem> EnviarMensagemAsync(int usuarioId, MensagemRequestDTO dto)
    {
        var respostaBotObj = await _gemini.EnviarMensagem(dto);


        var mensagem = new Mensagem
        { 
            Id = respostaBotObj.Id,
            TextoUsuario = dto.Texto,
            RespostaBot = respostaBotObj.RespostaBot,
            DataHora = DateTime.UtcNow,
            UsuarioId = usuarioId,
            
            
        };

        _context.Mensagens.Add(mensagem);
        await _context.SaveChangesAsync();

        return mensagem;
    }

    public async Task<List<Mensagem>> GetHistoricoAsync(int usuarioId)
    {
        return await _context.Mensagens
            .Where(m => m.UsuarioId == usuarioId)
            .OrderByDescending(m => m.DataHora)
            .ToListAsync();
    }

    public async Task<Mensagem> getMensagem(int id)
    {
        Mensagem? mensagem = await _context.Mensagens.FindAsync(id);
        if (mensagem != null)
        {
            return mensagem;
        }
        throw new KeyNotFoundException($"Mensagem com ID {id} não foi encontrada.");
    }

    public async Task<bool> UpdateMensagemAsync(int usuarioId, int mensagemId, MensagemRequestDTO dto)
    {
        var mensagem = await _context.Mensagens.FirstOrDefaultAsync(m => m.Id == mensagemId && m.UsuarioId == usuarioId);
        if (mensagem == null) return false;

        mensagem.TextoUsuario = dto.Texto;
        mensagem.RespostaBot = $"Atualizado: {dto.Texto}";
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteMensagemAsync(int usuarioId, int mensagemId)
    {
        var mensagem = await _context.Mensagens.FirstOrDefaultAsync(m => m.Id == mensagemId && m.UsuarioId == usuarioId);
        if (mensagem == null) return false;

        _context.Mensagens.Remove(mensagem);
        await _context.SaveChangesAsync();
        return true;
    }
}
