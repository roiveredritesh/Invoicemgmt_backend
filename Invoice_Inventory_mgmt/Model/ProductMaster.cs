using System.ComponentModel.DataAnnotations;

namespace Invoice_Inventory_mgmt.Model
{
    public class ProductMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter business id")]
        public int BusinessId { get; set; }

        [Required(ErrorMessage = "Please enter product code")]
        [Length(2, 50, ErrorMessage = "Product name should be atleast 2 character.")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Please enter product category id")]
        public int ProductCategoryId { get; set; }

        [Required(ErrorMessage ="Please enter product name")]
        [Length(2,50,ErrorMessage ="Product name should be atleast 2 character.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter product status")]
        [ValidStatus]
        public string ProductStatus { get; set; }

        [Required(ErrorMessage = "Please enter product price")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Please enter product type")]
        public string ProductType { get; set; }//inclusive & exclusive
        public decimal? ProductIGST { get; set; }
        public decimal? ProductSGST { get; set; }
        public decimal? ProductCGST { get; set; }

        [Required(ErrorMessage = "Please enter product details")]
        public string ProductDetails { get; set; }

    }

    public class CreateProductMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter business id")]
        public int BusinessId { get; set; }

        [Required(ErrorMessage = "Please enter product code")]
        [Length(2, 50, ErrorMessage = "Product name should be atleast 2 character.")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Please enter product category id")]
        public int ProductCategoryId { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        [Length(2, 50, ErrorMessage = "Product name should be atleast 2 character.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter product measure unit")]
        public string ProductMeasureUnit { get; set; }

        [Required(ErrorMessage = "Please enter product status")]
        [ValidStatus]
        public string ProductStatus { get; set; }

        [Required(ErrorMessage = "Please enter product price")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Please enter product type")]
        public string ProductType { get; set; }//inclusive & exclusive

        [Required(ErrorMessage ="Please enter product igst")]
        public decimal ProductIGST { get; set; }

        [Required(ErrorMessage = "Please enter product sgst")]
        public decimal ProductSGST { get; set; }

        [Required(ErrorMessage = "Please enter product cgst")]
        public decimal ProductCGST { get; set; }

        [Required(ErrorMessage = "Please enter product details")]
        public string ProductDetails { get; set; }

    }
}
