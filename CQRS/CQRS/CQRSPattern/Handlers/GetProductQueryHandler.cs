using CQRS.CQRSPattern.Results;
using CQRS.Dal;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context context;

        public GetProductQueryHandler(Context context)
        {
            this.context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = context.Products.Select(x => new GetProductQueryResult
            {
                Brand = x.Brand,
                Category = x.Category,
                Name = x.Name,
                Price = x.Price,
                ProductID = x.ProductID,
                Stock = x.Stock
            }).ToList();

            return values;
                
        }
    }
}
