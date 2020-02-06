using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCarvedRock.Api.Data.Contexts;
using MyCarvedRock.Api.Data.Entities;

namespace MyCarvedRock.Api.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<ProductReview>> GetForProductAsync(int productId)
        {
            if (productId <= 0) throw new ArgumentOutOfRangeException(nameof(productId));

            return await _dbContext.ProductReviews.Where(p => p.ProductId == productId).ToListAsync();
        }

        public async Task<ILookup<int, ProductReview>> GetForProductsAsync(IEnumerable<int> productIds)
        {
            if (productIds == null) throw new ArgumentNullException(nameof(productIds));
            var reviews = await _dbContext.ProductReviews.Where(pR => productIds.Contains(pR.ProductId)).ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }

        public IEnumerable<ProductReview> GetForProduct(int productId)
        {
            if (productId <= 0) throw new ArgumentOutOfRangeException(nameof(productId));

            return  _dbContext.ProductReviews.Where(p => p.ProductId == productId).ToList();
        }

        public ILookup<int, ProductReview> GetForProducts(IEnumerable<int> productIds)
        {
            if (productIds == null) throw new ArgumentNullException(nameof(productIds));
            var reviews = _dbContext.ProductReviews.Where(pR => productIds.Contains(pR.ProductId)).ToList();
            return reviews.ToLookup(r => r.ProductId);
        }

        public async Task<ProductReview> AddOneAsync(ProductReview review)
        {
            _dbContext.ProductReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}