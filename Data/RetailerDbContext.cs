using Microsoft.EntityFrameworkCore;
using RetailerAPI.Models.Domain;

namespace RetailerAPI.Data
{
    public class RetailerDbContext:DbContext
    {
        public RetailerDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Retailer> Retailers { get; set; }

    }
}
