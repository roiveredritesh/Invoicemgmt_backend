using Invoice_Inventory_mgmt.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Invoice_Inventory_mgmt.Model
{
    public class ProductCategoryMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid business id")]
        public int BusinessId { get; set; }
        [Required]
        [Length(1, 50)]
        public string ProductCategory_Name { get; set; }
        [Required]
        [Length(1, 20)]
        public string ProductCategory_Code { get; set; }
        [Required]
        [ValidStatus]
        public string ProductCategory_Status { get; set; }
        public DateTime? ProductCategory_CreatedOn { get; set; }
        public DateTime? ProductCategory_UpdatedOn { get; set; }

    }

    public class CreateProductCategory
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid business id")]
        public int BusinessId { get; set; }
        [Required]
        [Length(1, 50, ErrorMessage = "Product category name length can be max 50 characters only.")]
        public string ProductCategory_Name { get; set; }
        [Required]
        [Length(1, 20, ErrorMessage = "Product category code length can be max 20 characters only.")]
        public string ProductCategory_Code { get; set; }
        [Required]
        [ValidStatus]
        public string ProductCategory_Status { get; set; }
    }

    public class UpdateProductCategory
    {
        [Required]
        [Length(1, 50, ErrorMessage = "Product category name length can be max 50 characters only.")]
        public string ProductCategory_Name { get; set; }
        [Required]
        [Length(1, 20, ErrorMessage = "Product category code length can be max 20 characters only.")]
        public string ProductCategory_Code { get; set; }
        [Required]
        [ValidStatus]
        public string ProductCategory_Status { get; set; }
    }

    public class ValidStatusAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string status = value.ToString();
                if (status != "Active" && status != "Block")
                {
                    return new ValidationResult("Status must be either 'Active' or 'Block'.");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class PaginatedProductCategoryList
    {
        public PaginatedList<ProductCategoryMaster> PaginatedLists { get; set; }
        public int Count { get; set; }
    }

}
