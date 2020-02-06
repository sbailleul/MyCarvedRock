using System.Collections.Generic;
using System.Threading.Tasks;
using MyCarvedRock.Api.Data.Entities;

namespace MyCarvedRock.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        IEnumerable<Product> GetAll();
        Task<Product> GetOneAsync(int productÎd);

        Product GetOne(int productÎd);
    }
}