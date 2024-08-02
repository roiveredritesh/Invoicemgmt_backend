using Invoice_Inventory_mgmt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Inventory_mgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityMasterController : ControllerBase
    {
        public AppDBContext appDBContext { get; set; }
        public CityMasterController(AppDBContext _appDBContext)
        {
            appDBContext = _appDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await appDBContext.CityMasters.ToListAsync());
        }

        [HttpGet("/GetCity/{stateid}")]
        public async Task<IActionResult> GetCity(int stateid)
        {
            var cityList = await appDBContext.CityMasters.Where(city => city.StateID == stateid).OrderBy(city=>city.CityName).ToListAsync();
            return Ok(cityList);
        }
    }
}
