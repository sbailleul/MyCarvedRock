using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCarvedRock.Api.Data.Entities;

namespace MyCarvedRock.Api.Repositories
{
    public interface IProductReviewRepository
    {
        Task<IEnumerable<ProductReview>> GetForProductAsync(int productId);
        Task<ILookup<int, ProductReview>> GetForProductsAsync(IEnumerable<int> productIds);

        IEnumerable<ProductReview> GetForProduct(int productId);
        ILookup<int, ProductReview> GetForProducts(IEnumerable<int> productIds);
        Task<ProductReview> AddOneAsync(ProductReview review);
    }
}