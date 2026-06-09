using Gestor_Libros_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestor_Libros_EF.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

    }
}
