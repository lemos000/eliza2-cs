using eliza2_api.Data;
using eliza2_api.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eliza2_api.Pages.Mensagens
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Mensagem> Mensagens { get; set; }

        public async Task OnGetAsync()
        {
            Mensagens = await _context.Mensagens
                .Include(m => m.Usuario)
                .AsNoTracking()
                .OrderByDescending(m => m.DataHora)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);
            if (mensagem != null)
            {
                _context.Mensagens.Remove(mensagem);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
