using Microsoft.AspNetCore.Mvc;
using RetailerAPI.Models.Domain;

namespace RetailerAPI.Repositories
{
    public interface IRetailerRepository
    {
        Task<List<Retailer>>  GetAllAsync();
        Task<Retailer?> GetByIdAsync(Guid id);
        Task<Retailer> CreateAsync(Retailer retailer);
        Task<Retailer?> UpdateAsync(Guid id,Retailer retailer);
        Task<Retailer?> DeleteAsync(Guid id);
    }
}
