using Flash_Fusion.Core._System.Models;
using Microsoft.EntityFrameworkCore;

namespace Flash_Fusion.EntityFrameWorkCore._System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> users { get; set; }
    }
}
