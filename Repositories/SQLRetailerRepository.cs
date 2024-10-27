using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RetailerAPI.Data;
using RetailerAPI.Models.Domain;

namespace RetailerAPI.Repositories
{
    public class SQLRetailerRepository : IRetailerRepository
    {
        private readonly RetailerDbContext dbContext;

        public SQLRetailerRepository(RetailerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Retailer>> GetAllAsync()
        {
          return await dbContext.Retailers.ToListAsync();
        }

        public async Task<Retailer?> GetByIdAsync(Guid id)
        {
           return await dbContext.Retailers.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Retailer> CreateAsync(Retailer retailer)
        {
           await dbContext.Retailers.AddAsync(retailer);
           await dbContext.SaveChangesAsync();
           return retailer;
        }

        public async Task<Retailer?> UpdateAsync(Guid id, Retailer retailer)
        {
           var existingRetailer=await dbContext.Retailers.FirstOrDefaultAsync( x=>x.Id == id);

            if (existingRetailer == null)
            {
                return null;
            }

            existingRetailer.Name = retailer.Name;
            existingRetailer.Description = retailer.Description;
            existingRetailer.Phone = retailer.Phone;
            existingRetailer.Email = retailer.Email;

            await dbContext.SaveChangesAsync();

            return existingRetailer;

        }

        public async Task<Retailer?> DeleteAsync(Guid id)
        {
            var existingRetailer = await dbContext.Retailers.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRetailer == null)
            {
                return null;
            }

            dbContext.Retailers.Remove(existingRetailer);
            await dbContext.SaveChangesAsync();
            return existingRetailer;
        }
    }
}
