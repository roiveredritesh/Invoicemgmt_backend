using Invoice_Inventory_mgmt.Data;
using Invoice_Inventory_mgmt.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Inventory_mgmt.Repository
{
    public class BusinessRegistrationRL : IBusinessRegistrationRL
    {
        private readonly AppDBContext _context;

        public BusinessRegistrationRL(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BusinessRegistration>> GetAllAsync()
        {
            return await _context.BusinessRegistrations.ToListAsync();
        }

        public async Task<BusinessRegistration> GetByIdAsync(int id)
        {
            return await _context.BusinessRegistrations.FindAsync(id);
        }

        public async Task AddAsync(BusinessRegistration businessRegistration)
        {
            await _context.BusinessRegistrations.AddAsync(businessRegistration);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BusinessRegistration businessRegistration)
        {
            _context.BusinessRegistrations.Update(businessRegistration);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.BusinessRegistrations.FindAsync(id);
            if (entity != null)
            {
                _context.BusinessRegistrations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
