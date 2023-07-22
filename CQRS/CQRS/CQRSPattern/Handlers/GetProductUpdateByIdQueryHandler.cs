using CQRS.CQRSPattern.Queries;
using CQRS.CQRSPattern.Results;
using CQRS.Dal;

namespace CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateByIdQueryHandler
    {
        private readonly Context context;

        public GetProductUpdateByIdQueryHandler(Context context)
        {
            this.context = context;
        }

        public GetProductUpdateByIdQueryResult Handle(GetProductUpdateByIdQuery query)
        {
            var value = context.Products.Find(query.Id);
            return new GetProductUpdateByIdQueryResult
            {
                Brand = value.Brand,
                Category = value.Category,
                Name = value.Name,
                Price = value.Price,
                ProductID = value.ProductID,
                Stock = value.Stock
            };
        }
    }
}
