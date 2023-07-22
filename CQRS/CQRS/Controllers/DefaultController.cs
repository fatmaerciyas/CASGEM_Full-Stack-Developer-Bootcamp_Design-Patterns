using CQRS.CQRSPattern.Commands;
using CQRS.CQRSPattern.Handlers;
using CQRS.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler getProductQueryHandler;
        private readonly CreateProductCommandHandler createProductCommandHandler;
        private readonly RemoveProductCommandHandler removeProductCommandHandler;
        private readonly GetProductByIdQueryHandler getProductByIdQueryHandler;
        private readonly GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler;
        private readonly UpdateProductCommandHandler updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            this.getProductQueryHandler = getProductQueryHandler;
            this.createProductCommandHandler = createProductCommandHandler;
            this.removeProductCommandHandler = removeProductCommandHandler;
            this.getProductByIdQueryHandler = getProductByIdQueryHandler;
            this.getProductUpdateByIdQueryHandler = getProductUpdateByIdQueryHandler;
            this.updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = getProductQueryHandler.Handle();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct( CreateProductCommand command)
        {
            createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(RemoveProductCommand command)
        {
            removeProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(GetProductByIdQuery query)
        {
            var values = getProductByIdQueryHandler.Handle(query);
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
