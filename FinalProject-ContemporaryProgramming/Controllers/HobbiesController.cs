using FinalProject_ContemporaryProgramming.Data;
using FinalProject_ContemporaryProgramming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FinalProject_ContemporaryProgramming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly ILogger<HobbiesController> _logger;
        private readonly DefaultContext _context;

        public HobbiesController(ILogger<HobbiesController> logger, DefaultContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetHobbies")]
        [Route("/")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Hobbies.ToList());
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "SQL error occurred while fetching hobby");
                return StatusCode(500, "Database error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hobby");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
