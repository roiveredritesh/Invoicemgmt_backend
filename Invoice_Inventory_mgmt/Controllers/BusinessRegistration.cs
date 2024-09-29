using Invoice_Inventory_mgmt.Data;
using Invoice_Inventory_mgmt.Model;
using Invoice_Inventory_mgmt.Service;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Inventory_mgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessRegistrationController : ControllerBase
    {
        public AppDBContext appDBContext { get; set; }

        private readonly IBusinessRegistrationSL _service;

        public BusinessRegistrationController(IBusinessRegistrationSL service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessRegistration>>> GetAll()
        {
            var businesses = await _service.GetAllBusinessesAsync();
            return Ok(businesses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessRegistration>> GetById(int id)
        {
            var business = await _service.GetBusinessByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            return Ok(business);
        }

        [HttpPost]
        public async Task<ActionResult> Add(BusinessRegistration businessRegistration)
        {
            await _service.AddBusinessAsync(businessRegistration);
            return CreatedAtAction(nameof(GetById), new { id = businessRegistration.BusinessId }, businessRegistration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BusinessRegistration businessRegistration)
        {
            if (id != businessRegistration.BusinessId)
            {
                return BadRequest();
            }

            await _service.UpdateBusinessAsync(businessRegistration);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var business = await _service.GetBusinessByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            await _service.DeleteBusinessAsync(id);
            return NoContent();
        }
    }
}
