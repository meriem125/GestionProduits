using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonProjetFac.Data;
using MonProjetFac.Models;

namespace MonProjetFac.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produit Produit { get; set; } = new();

        public SelectList Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            await ChargerCategories();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Produit.Categorie");

            if (!ModelState.IsValid)
            {
                await ChargerCategories();
                return Page();
            }

            _context.Produits.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Produits");
        }

        private async Task ChargerCategories()
        {
            var liste = await _context.Categories.OrderBy(c => c.Nom).ToListAsync();
            Categories = new SelectList(liste, "Id", "Nom");
        }
    }
}