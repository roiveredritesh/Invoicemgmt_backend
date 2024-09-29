using Invoice_Inventory_mgmt.Model;
using Invoice_Inventory_mgmt.Repository;

namespace Invoice_Inventory_mgmt.Service
{
    public class BusinessRegistrationSL : IBusinessRegistrationSL
    {
        private readonly IBusinessRegistrationRL _repository;

        public BusinessRegistrationSL(IBusinessRegistrationRL repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BusinessRegistration>> GetAllBusinessesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<BusinessRegistration> GetBusinessByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddBusinessAsync(BusinessRegistration businessRegistration)
        {
            await _repository.AddAsync(businessRegistration);
        }

        public async Task UpdateBusinessAsync(BusinessRegistration businessRegistration)
        {
            await _repository.UpdateAsync(businessRegistration);
        }

        public async Task DeleteBusinessAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
