using CrudOpWithRazor.DAL;
using CrudOpWithRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudOpWithRazor.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public DeleteModel(MyAppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == itemid);

            if (product == null)
            {
                return NotFound();
            }
            Products = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? itemid) 
        {
            if(itemid == null) 
            {
                return Page();
            }
            var  product = await _context.Products.FindAsync(itemid);
            if (product == null) 
            {
                return NotFound();
            }
            Products = product;
            _context.Products.Remove(Products);
            await _context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
