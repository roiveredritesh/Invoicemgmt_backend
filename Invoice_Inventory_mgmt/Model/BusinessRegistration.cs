using System.ComponentModel.DataAnnotations;

namespace Invoice_Inventory_mgmt.Model
{
    public class BusinessRegistration
    {
        [Key]
        public int BusinessId { get; set; }
        [Required]
        [Length(1, 200)]
        public required string BusinessName { get; set; }

        [Required]
        [Length(1, 10)]
        public required string BusinessContactNo { get; set; }

        [Length(1, 2000)]
        public string BusinessAddress { get; set; } = string.Empty;
        public int BusinessStateId { get; set; }
        public int BusinessCityId { get; set; }
        public int BusinessPincode { get; set; } = 0;
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactPersonContactNo { get; set; } = string.Empty;
        public string BusinessContactNumber { get; set; } = string.Empty;
        public string BusinessAltContactNumber { get; set; } = string.Empty;
        public string BusinessGSTIN { get; set; } = string.Empty;
        public string BusinessGSTScheme { get; set; } = string.Empty;

        [Required]
        [Length(1, 200)]
        public required string BusinessType { get; set; }

        [Required]
        [Length(1, 200)]
        public required string BusinessEmailId { get; set; }

        [Required]
        [Length(1, 50)]
        public required string Password { get; set; }

    }
}
