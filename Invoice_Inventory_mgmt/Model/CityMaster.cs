using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice_Inventory_mgmt.Model
{
    public class CityMaster
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int StateID { get; set; }


    }
}
