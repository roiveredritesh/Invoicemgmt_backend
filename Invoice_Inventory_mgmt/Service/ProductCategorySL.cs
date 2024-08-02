using Invoice_Inventory_mgmt.Common;
using Invoice_Inventory_mgmt.Model;
using Invoice_Inventory_mgmt.Repository;

namespace Invoice_Inventory_mgmt.Service
{
    public class ProductCategorySL : IProductCategorySL
    {
        private readonly IProductCategoryRL _producatCategoryRL;

        public ProductCategorySL(IProductCategoryRL producatCategoryRL)
        {
            _producatCategoryRL = producatCategoryRL;
        }
        public async Task<List<ProductCategoryMaster>> AddProductCategory(CreateProductCategory create_productcategory)
        {
            try
            {
                ProductCategoryMaster oPM = await _producatCategoryRL.AddProductCategory(create_productcategory);
                var productCategoryList = Enumerable.Repeat(oPM, 1).ToList();
                return productCategoryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding product category: {ex}");
                throw new ApplicationException("An error occurred while adding the product category.");
            }
        }

        public async Task<List<ProductCategoryMaster>> GetProductCategory(int id)
        {
            try
            {
                ProductCategoryMaster oPM = await _producatCategoryRL.GetProductCategory(id);
                var productCategoryList = Enumerable.Repeat(oPM, 1).ToList();
                return productCategoryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product category: {ex}");
                throw new ApplicationException("An error occurred while fetching the product category.");
            }
        }

        public async Task<List<ProductCategoryMaster>> GetProductCategoryList()
        {
            try
            {
                List<ProductCategoryMaster> oPM = await _producatCategoryRL.GetProductCategoryList();
                return oPM;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product categories: {ex}");
                throw new ApplicationException("An error occurred while fetching the product categories.");
            }
        }

        public async Task<List<ProductCategoryMaster>> UpdateProductCategory(int id, UpdateProductCategory update_productcategory)
        {
            try
            {
                ProductCategoryMaster oPM = await _producatCategoryRL.UpdateProductCategory(id, update_productcategory);
                var productCategoryList = Enumerable.Repeat(oPM, 1).ToList();
                return productCategoryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating product categories: {ex}");
                throw new ApplicationException("An error occurred while updating the product categories.");
            }
        }

        public async Task<PaginatedProductCategoryList> SearchProductCategoryList(string name, string code, string status, int businessid, int pageNumber, int pageSize)
        {
            try
            {
                PaginatedProductCategoryList oPM = await _producatCategoryRL.SearchProductCategory(name, code, status, businessid, pageNumber, pageSize);
                return oPM;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching product categories: {ex}");
                throw new ApplicationException("An error occurred while searching the product categories.");
            }
        }

        public async Task<List<ProductCategoryMaster>> FilterProductCategoryListByStatus(int businessId, string? status)
        {
            try
            {
                List<ProductCategoryMaster> oPM = await _producatCategoryRL.FilterProductCategoryListByStatus(businessId, status);
                return oPM;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching filtered product categories: {ex}");
                throw new ApplicationException("An error occurred while fetching filtered product categories.");
            }
        }
    }
}
