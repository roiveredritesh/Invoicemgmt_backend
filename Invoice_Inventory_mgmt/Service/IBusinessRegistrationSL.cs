using Invoice_Inventory_mgmt.Model;

namespace Invoice_Inventory_mgmt.Service
{
    public interface IBusinessRegistrationSL
    {
        Task<IEnumerable<BusinessRegistration>> GetAllBusinessesAsync();
        Task<BusinessRegistration> GetBusinessByIdAsync(int id);
        Task AddBusinessAsync(BusinessRegistration businessRegistration);
        Task UpdateBusinessAsync(BusinessRegistration businessRegistration);
        Task DeleteBusinessAsync(int id);
    }
}
