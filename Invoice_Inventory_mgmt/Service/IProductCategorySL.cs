using Invoice_Inventory_mgmt.Common;
using Invoice_Inventory_mgmt.Model;

namespace Invoice_Inventory_mgmt.Service
{
    public interface IProductCategorySL
    {
        Task<List<ProductCategoryMaster>> GetProductCategoryList();

        Task<List<ProductCategoryMaster>> FilterProductCategoryListByStatus(int businessId, string? status);
        Task<List<ProductCategoryMaster>> GetProductCategory(int id);
        Task<List<ProductCategoryMaster>> AddProductCategory(CreateProductCategory create_productcategory);
        Task<List<ProductCategoryMaster>> UpdateProductCategory(int id, UpdateProductCategory update_productcategory);
        Task<PaginatedProductCategoryList> SearchProductCategoryList(string? name, string? code, string? status, int businessid, int pageNumber, int pageSize);
    }
}
