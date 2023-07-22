using CQRS.CQRSPattern.Commands;
using CQRS.Dal;

namespace CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context context;

        public UpdateProductCommandHandler(Context context)
        {
            this.context = context;
        }

        public void Handle(UpdateProductCommand command)
        {
            var values = context.Products.Find(command.ProductID);

            values.Brand = command.Brand;
            values.Price = command.Price;
            values.Stock = command.Stock;
            values.Category = command.Category;
            values.Name = command.Name;

            context.SaveChanges();
        }
    }
}
