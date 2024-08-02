using Invoice_Inventory_mgmt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Inventory_mgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateMasterController : ControllerBase
    {
        public AppDBContext appDBContext { get; set; }
        public StateMasterController(AppDBContext _appDBContext)
        {
            appDBContext = _appDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await appDBContext.StateMasters.ToListAsync());
        }
    }
}
