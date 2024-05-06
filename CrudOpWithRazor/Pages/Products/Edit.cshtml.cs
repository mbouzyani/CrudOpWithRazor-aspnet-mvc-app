using CrudOpWithRazor.DAL;
using CrudOpWithRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudOpWithRazor.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public EditModel(MyAppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if(itemid == null || _context.Products == null) 
            {
                return  NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == itemid);

            if (product == null) 
            {
                return NotFound();
            }
            Products = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) 
            {
                return Page();
            }
            _context.Products.Update(Products);
            await _context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
