using Invoice_Inventory_mgmt.Common;
using Invoice_Inventory_mgmt.Model;

namespace Invoice_Inventory_mgmt.Repository
{
    public interface IProductCategoryRL
    {
        Task<List<ProductCategoryMaster>> GetProductCategoryList();
        Task<List<ProductCategoryMaster>> FilterProductCategoryListByStatus(int businessId, string? status);
        Task<ProductCategoryMaster> GetProductCategory(int id);
        Task<ProductCategoryMaster> AddProductCategory(CreateProductCategory create_productcategory);
        Task<ProductCategoryMaster> UpdateProductCategory(int id, UpdateProductCategory update_productcategory);
        Task<PaginatedProductCategoryList> SearchProductCategory(string? name, string? code, string? status, int businessid, int pageNumber, int pageSize);
    }
}
