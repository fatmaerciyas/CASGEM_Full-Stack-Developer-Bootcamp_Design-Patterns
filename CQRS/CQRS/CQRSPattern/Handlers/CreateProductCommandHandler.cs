using CQRS.CQRSPattern.Commands;
using CQRS.Dal;

namespace CQRS.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context context;

        public CreateProductCommandHandler(Context context)
        {
            this.context = context;
        }

        public void Handle(CreateProductCommand command)
        {
            context.Products.Add(new Product {
                Brand = command.Brand,
                Category = command.Category,
                Name = command.Name,
                Price = command.Price,
                Stock = command.Stock
                });

            context.SaveChanges();
        }
    }
}
