using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonProjetFac.Data;
using MonProjetFac.Models;

namespace MonProjetFac.Pages
{
    public class ProduitsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProduitsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Produit> ListeProduits { get; set; } = new();

        public async Task OnGetAsync()
        {
            ListeProduits = await _context.Produits
                .Include(p => p.Categorie)
                .ToListAsync();
        }
    }
}