using CQRS.CQRSPattern.Queries;
using CQRS.CQRSPattern.Results;
using CQRS.Dal;

namespace CQRS.CQRSPattern.Handlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly Context context;

        public GetProductByIdQueryHandler(Context context)
        {
            this.context = context;
        }

        public GetProductByIdQueryResult Handle(GetProductByIdQuery query)
        {
            var values = context.Products.Find(query.Id);
            return new GetProductByIdQueryResult
            {
                ProductID = values.ProductID,
                ProductBrand = values.Brand,
                Name = values.Name
            };
        }
    }
}
