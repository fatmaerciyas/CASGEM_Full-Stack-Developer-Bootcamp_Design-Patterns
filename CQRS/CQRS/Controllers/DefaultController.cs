using CQRS.CQRSPattern.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler getProductQueryHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler)
        {
            this.getProductQueryHandler = getProductQueryHandler;
        }

        public IActionResult Index()
        {
            var values = getProductQueryHandler.Handle();
            return View(values);
        }
    }
}
