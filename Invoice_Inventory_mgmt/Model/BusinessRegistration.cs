using System.ComponentModel.DataAnnotations;

namespace Invoice_Inventory_mgmt.Model
{
    public class BusinessRegistration
    {
        [Key]
        public int BusinessId { get; set; }
        [Required]
        [Length(1,200)]
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }=string.Empty;
        public int BusinessStateId { get; set; }
        public int BusinessCityId { get; set; }
        public int BusinessPincode { get; set; } = 0;
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactPersonContactNo { get; set; } = string.Empty;
        public string BusinessContactNumber { get; set; } = string.Empty;
        public string BusinessAltContactNumber { get; set; } = string.Empty;
        public string BusinessGSTIN { get; set; } = string.Empty;
        public string BusinessGSTScheme { get; set; } = string.Empty;
        public string BusinessType { get; set; } = string.Empty;
        public string BusinessEmailId { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }

    }
}
