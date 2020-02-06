using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace MyCarvedRock.Api.GraphQL
{
    public class CarvedRockSchema: Schema
    {
        public CarvedRockSchema(IServiceProvider services): base(services)
        {           
            Query = services.GetService<CarvedRockQuery>();
            Mutation = services.GetService<CarvedRockMutation>();
        }
    }
}
