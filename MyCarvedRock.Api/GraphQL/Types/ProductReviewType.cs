using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MyCarvedRock.Api.Data.Entities;

namespace MyCarvedRock.Api.GraphQL.Types
{
    public sealed class ProductReviewType: ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
