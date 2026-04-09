using FinalProject_ContemporaryProgramming.Data;
using FinalProject_ContemporaryProgramming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FinalProject_ContemporaryProgramming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : ControllerBase
    {
        private readonly ILogger<TeamMemberController> _logger;
        private readonly DefaultContext _context;

        public TeamMemberController(ILogger<TeamMemberController> logger, DefaultContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetTeamMembers")]
        [Route("/")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.TeamMembers.ToList());
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "SQL error occurred while fetching team member");
                return StatusCode(500, "Database error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching team member");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "GetTeamMembersById")]
        [Route("/{id}")]
        public IActionResult GetMemberById(int? id)
        {
            try
            {
                if (id == null || id== 0)
                {
                    return Ok(_context.TeamMembers.ToList().Take(5));
                }

                var member = _context.TeamMembers.FirstOrDefault(m => m.TeamMemberId == id);
                if (member == null)
                {
                    return NotFound();
                }
                return Ok(member);
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "SQL error occurred while fetching team member with ID {Id}", id);
                return StatusCode(500, "Database error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching team member with ID {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
