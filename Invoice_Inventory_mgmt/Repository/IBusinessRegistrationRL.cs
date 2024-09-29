using Invoice_Inventory_mgmt.Model;

namespace Invoice_Inventory_mgmt.Repository
{
    public interface IBusinessRegistrationRL
    {
        Task<IEnumerable<BusinessRegistration>> GetAllAsync();
        Task<BusinessRegistration> GetByIdAsync(int id);
        Task AddAsync(BusinessRegistration businessRegistration);
        Task UpdateAsync(BusinessRegistration businessRegistration);
        Task DeleteAsync(int id);
    }

}
