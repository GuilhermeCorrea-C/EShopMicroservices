﻿
namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdResult(Product Product);
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    internal class GetProductByIdHandler
        (IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            return product is null ? throw new ProductNotFoundException(query.Id) : new GetProductByIdResult(product);
        }
    }
}
