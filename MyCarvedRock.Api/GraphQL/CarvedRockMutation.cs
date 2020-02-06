using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MyCarvedRock.Api.Data.Entities;
using MyCarvedRock.Api.GraphQL.Types;
using MyCarvedRock.Api.Repositories;

namespace MyCarvedRock.Api.GraphQL
{
    public class CarvedRockMutation: ObjectGraphType
    {
        public CarvedRockMutation(IProductReviewRepository productReviewRepository)
        {
            FieldAsync<ProductReviewType>("createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>>
                    {
                        Name = "review"
                    }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    await context.TryAsyncResolve(async c => await productReviewRepository.AddOneAsync(review));
                    return review;
                });

        }
    }
}
