using BeSpoked_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked_Bikes.Data
{
    public class ProductsContoller:IProductsContoller
    {
        private readonly ApplicationDbContext _context;
        public ProductsContoller(ApplicationDbContext context) { _context = context; }

        public async Task<int> Create( Product product)
        {
           
                _context.Add(product);
             return  await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> List()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<bool> edit(Product product)
        {
            if (product.Id == null || _context.Product == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }


    }
    public interface IProductsContoller
    {
        Task<List<Product>> List();
        Task<bool> edit(Product product);
        Task<int> Create(Product product);
    }
}
