using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice_Inventory_mgmt.Model
{
    public class StateMaster
    {
        [Key]
        public int StateID { get; set; }
        public string StateName { get; set; }

        [ForeignKey("StateID")]
        public ICollection<CityMaster> CityMasters { get; set; }

    }
}
