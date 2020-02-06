using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCarvedRock.Api.Data.Contexts;
using MyCarvedRock.Api.Data.Entities;

namespace MyCarvedRock.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public async Task<Product> GetOneAsync(int productÎd)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productÎd);
        }

        public Product GetOne(int productÎd)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == productÎd);
        }
    }
}
