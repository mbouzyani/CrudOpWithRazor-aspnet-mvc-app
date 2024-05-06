using CrudOpWithRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOpWithRazor.DAL
{
    public class MyAppDbContext : DbContext
    {

        public MyAppDbContext(DbContextOptions options) : base
        (options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
