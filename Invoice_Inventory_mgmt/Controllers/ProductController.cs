using Invoice_Inventory_mgmt.Common;
using Invoice_Inventory_mgmt.Model;
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var productCategoryList = await _productCategorySL.GetProductCategoryList();
                if (productCategoryList == null || !productCategoryList.Any())
                {
                    return NotFound(new CustomResponse<object> { Code = 404, Message = "Products not found", Data = null });
                }
                return Ok(new CustomResponse<List<ProductCategoryMaster>> { Code = 200, Message = "Success", Data = productCategoryList });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching products: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching products.");
            }
        }

    }
}
