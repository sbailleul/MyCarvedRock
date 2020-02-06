using System.Security.Claims;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Validation.Rules;
using MyCarvedRock.Api.Data.Entities;
using MyCarvedRock.Api.Repositories;

namespace MyCarvedRock.Api.GraphQL.Types
{
    public sealed class ProductType: ObjectGraphType<Product>
    {
        public ProductType(IProductReviewRepository productReviewRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the product");
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<ProductTypeEnumType>("Type", "The type of product");
            Field<ListGraphType<ProductReviewType>>("Reviews", 
                resolve:  context =>
                {
                    var user = (ClaimsPrincipal) context.UserContext["user"];
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                        "GetReviewsProductId", productReviewRepository.GetForProductsAsync);
                    return  loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
