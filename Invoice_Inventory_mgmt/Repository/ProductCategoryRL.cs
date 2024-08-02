using Invoice_Inventory_mgmt.Common;
using Invoice_Inventory_mgmt.Data;
using Invoice_Inventory_mgmt.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Invoice_Inventory_mgmt.Repository
{
    public class ProductCategoryRL : IProductCategoryRL
    {
        public readonly AppDBContext _appContext;

        public ProductCategoryRL(AppDBContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<ProductCategoryMaster> AddProductCategory(CreateProductCategory create_productcategory)
        {
            try
            {
                ProductCategoryMaster oPM = new ProductCategoryMaster
                {
                    Id = 0,
                    BusinessId = create_productcategory.BusinessId,
                    ProductCategory_Code = create_productcategory.ProductCategory_Code,
                    ProductCategory_CreatedOn = DateTime.UtcNow.AddHours(5.45),
                    ProductCategory_Name = create_productcategory.ProductCategory_Name,
                    ProductCategory_Status = create_productcategory.ProductCategory_Status
                };
                _appContext.ProductCategoryMasters.Add(oPM);
                await _appContext.SaveChangesAsync();
                return oPM;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error occurred while saving changes to the database: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw new ApplicationException("An error occurred while adding the product category.");
            }
        }
        public async Task<ProductCategoryMaster> GetProductCategory(int id)
        {
            try
            {
                var productCategories = await _appContext.ProductCategoryMasters.FirstOrDefaultAsync(p => p.Id == id);
                if (productCategories == null)
                    return null;
                return productCategories;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error occurred while selecting product category to the database: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw new ApplicationException("An error occurred while selecting the product category.");
            }
        }
        public async Task<List<ProductCategoryMaster>> GetProductCategoryList()
        {
            try
            {
                var productCategories = await _appContext.ProductCategoryMasters.ToListAsync();
                if (productCategories == null)
                    return null;
                return productCategories;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error occurred while selecting category list to the database: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw new ApplicationException("An error occurred while selecting product category list.");
            }
        }
        public async Task<ProductCategoryMaster> UpdateProductCategory(int id, UpdateProductCategory update_productcategory)
        {
            try
            {
                var productCategory = await _appContext.ProductCategoryMasters.FirstOrDefaultAsync(p => p.Id == id);
                if (productCategory == null)
                    return null;

                productCategory.ProductCategory_Code = update_productcategory.ProductCategory_Code;
                productCategory.ProductCategory_UpdatedOn = DateTime.UtcNow.AddHours(5.45);
                productCategory.ProductCategory_Name = update_productcategory.ProductCategory_Name;
                productCategory.ProductCategory_Status = update_productcategory.ProductCategory_Status;
                await _appContext.SaveChangesAsync();
                return productCategory;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error occurred while updating changes to the database: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw new ApplicationException("An error occurred while updating the product category.");
            }
        }
        public async Task<PaginatedProductCategoryList> SearchProductCategory(string name, string code, string status, int businessid, int pageNumber, int pageSize)
        {
            try
            {
                var productCategories = _appContext.ProductCategoryMasters.Where(p => p.BusinessId == businessid && EF.Functions.Like(p.ProductCategory_Name, $"%{name}%") && EF.Functions.Like(p.ProductCategory_Code, $"%{code}%") && EF.Functions.Like(p.ProductCategory_Status, $"%{status}%"));
                int count = productCategories.Count();
                var filteredlist = await PaginatedList<ProductCategoryMaster>.ToPagedList(productCategories, pageNumber, pageSize);
                return new PaginatedProductCategoryList { PaginatedLists = filteredlist, Count = count };
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error occurred while selecting product category to the database: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw new ApplicationException("An error occurred while selecting the product category.");
            }
        }

        public async Task<List<ProductCategoryMaster>> FilterProductCategoryListByStatus(int businessId, string? status)
        {
            try
            {
                var productCategories = _appContext.ProductCategoryMasters.Where(pc => pc.BusinessId == businessId);
                if (!string.IsNullOrEmpty(status))
                {
                    productCategories = productCategories.Where(pc => pc.ProductCategory_Status == status);
                }
                return await productCategories.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error occurred while selecting category list to the database: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw new ApplicationException("An error occurred while selecting product category list.");
            }
        }
    }
}
