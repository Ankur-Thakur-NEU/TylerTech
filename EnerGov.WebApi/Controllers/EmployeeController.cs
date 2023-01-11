using EnerGov.Core;
using EnerGov.WebApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EnerGov.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDbHelper _db;
        public EmployeeController(IDbHelper db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _db.GetAllByManagerID(id);
            return Ok(data);
        }

        [HttpGet()]
        public async Task<IActionResult> getAllManagers()
        {
            var data = await _db.GetAllManagers();
            return Ok(data);
        }

        [HttpGet("getAllRoles")]
        public async Task<IActionResult> getAllRoles()
        {
            List<RoleResponse> rolesResponse = new List<RoleResponse>();
            Dictionary<string, int> days = Enum.GetValues(typeof(Roles))
                                        .Cast<Roles>()
                                        .ToDictionary(k => k.ToString(), v => (int)v);
            foreach (var day in days)
            {
                rolesResponse.Add(new RoleResponse { Id = day.Value, Name = day.Key });
            }
            return Ok(rolesResponse);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] EmployeeRequest account)
        {
            try
            {
                return Ok(await _db.SaveAccount(account));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
