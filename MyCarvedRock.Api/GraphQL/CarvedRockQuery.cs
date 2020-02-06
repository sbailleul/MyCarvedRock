using GraphQL;
using GraphQL.Types;
using MyCarvedRock.Api.GraphQL.Types;
using MyCarvedRock.Api.Repositories;

namespace MyCarvedRock.Api.GraphQL
{
    public class CarvedRockQuery: ObjectGraphType
    {
        public CarvedRockQuery(IProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products", 
                resolve: context =>
                {
                    context.Errors.Add(new ExecutionError("My custom message"));
                    return productRepository.GetAll();
                });
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id"
                    }),
                resolve: context => productRepository.GetOne(context.GetArgument<int>("id")));
        }
    }
}
