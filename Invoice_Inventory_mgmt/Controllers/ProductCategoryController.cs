using Invoice_Inventory_mgmt.Common;
using Invoice_Inventory_mgmt.Data;
using Invoice_Inventory_mgmt.Model;
using Invoice_Inventory_mgmt.Repository;
using Invoice_Inventory_mgmt.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Inventory_mgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategorySL _productCategorySL;

        public ProductCategoryController(IProductCategorySL productCategorySL)
        {
            _productCategorySL = productCategorySL;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            try
            {
                var productCategoryList = await _productCategorySL.GetProductCategoryList();
                if (productCategoryList == null || !productCategoryList.Any())
                {
                    return NotFound(new CustomResponse<object> { Code = 404, Message = "Product categories not found", Data = null });
                }
                return Ok(new CustomResponse<List<ProductCategoryMaster>> { Code = 200, Message = "Success", Data = productCategoryList });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product categories: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching product categories.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest(new CustomResponse<object> { Code = 400, Message = "Invalid id.", Data = null });
                }
                var productCategory = await _productCategorySL.GetProductCategory(id);
                if (productCategory == null)
                {
                    return NotFound(new CustomResponse<object> { Code = 404, Message = $"Product category with ID {id} not found.", Data = null });
                }
                return Ok(new CustomResponse<List<ProductCategoryMaster>> { Code = 200, Message = "Success", Data = productCategory });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product category: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching product category.");
            }
        }


        [HttpGet("filter")]
        public async Task<IActionResult> FilteredProductCategories(int businessid, string? status = null)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(businessid)))
                {
                    return BadRequest(new CustomResponse<object> { Code = 400, Message = "Business id can not be blank.", Data = null });
                }
                if (businessid == 0)
                {
                    return BadRequest(new CustomResponse<object> { Code = 400, Message = "Invalid business id.", Data = null });
                }
                var productCategoryList = await _productCategorySL.FilterProductCategoryListByStatus(businessid, status);
                if (productCategoryList == null || !productCategoryList.Any())
                {
                    return NotFound(new CustomResponse<object> { Code = 404, Message = "No product categories found for the specified search criteria.", Data = null });
                }
                return Ok(new CustomResponse<List<ProductCategoryMaster>> { Code = 200, Message = "Success", Data = productCategoryList });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching filtered product categories: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching filtered product categories.");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchProductCategory(int businessid, int pageNumber = 1, int pageSize = 10, string? name = null, string? code = null, string? status = null)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(businessid)))
                {
                    return BadRequest(new CustomSearchResponse<object> { Code = 400, TotalCount = "0", Message = "Business id can not be blank.", Data = null });
                }
                if (businessid == 0)
                {
                    return BadRequest(new CustomSearchResponse<object> { Code = 400, TotalCount = "0", Message = "Invalid business id.", Data = null });
                }
                var productCategory = await _productCategorySL.SearchProductCategoryList(name, code, status, businessid, pageNumber, pageSize);
                if (productCategory.PaginatedLists == null || !productCategory.PaginatedLists.Any())
                {
                    return NotFound(new CustomResponse<object> { Code = 404, Message = "No product categories found for the specified search criteria.", Data = null });
                }
                return Ok(new CustomSearchResponse<List<ProductCategoryMaster>> { Code = 200, Message = "Success", TotalCount = productCategory.Count.ToString(), Data = productCategory.PaginatedLists });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product category: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching product category.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveProductCategory([FromBody] CreateProductCategory createProductCategory)
        {
            try
            {
                var productcategory = await _productCategorySL.AddProductCategory(createProductCategory);
                if (productcategory == null)
                {
                    return NotFound(new CustomResponse<object> { Code = 400, Message = "Failed to save product category.", Data = null });
                }
                return Ok(new CustomResponse<List<ProductCategoryMaster>> { Code = 200, Message = "Success", Data = productcategory });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving product category: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving product category.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory(int id, [FromBody] UpdateProductCategory updateProductCategory)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest(new CustomResponse<object> { Code = 400, Message = "Invalid product category ID.", Data = null });
                }
                var productcategory = await _productCategorySL.UpdateProductCategory(id, updateProductCategory);
                if (productcategory == null)
                {
                    return NotFound(new CustomResponse<object> { Code = 404, Message = $"Product category with ID {id} not found.", Data = null });
                }
                return Ok(new CustomResponse<List<ProductCategoryMaster>> { Code = 200, Message = "Success", Data = productcategory });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating product category: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating product category.");
            }
        }
    }
}
