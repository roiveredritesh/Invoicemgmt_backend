using Invoice_Inventory_mgmt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Inventory_mgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductCategorySL _productCategorySL;

        public ProductController(IProductCategorySL productCategorySL)
        {
            _productCategorySL = productCategorySL;
        }

    }
}
