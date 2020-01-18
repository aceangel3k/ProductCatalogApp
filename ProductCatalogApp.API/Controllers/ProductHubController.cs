using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProductCatalogApp.API.Data;
using ProductCatalogApp.API.Hubs;

namespace ProductCatalogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductHubController : ControllerBase
    {
        private readonly IHubContext<ProductHub> _hub;
        private readonly IProductRepository _repo;
        public ProductHubController(IHubContext<ProductHub> hub, IProductRepository productRepo)
        {
            _repo = productRepo;
            _hub = hub;
        }

        public IActionResult Get()
        {
            _hub.Clients.All.SendAsync("transferproductdata", ProductStore.Instance.Products);
            return Ok(new { Message = "Request Completed" });
        }
    }
}