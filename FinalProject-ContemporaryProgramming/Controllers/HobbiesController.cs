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

        [HttpPut]
        public IActionResult Update(int? id, [FromBody] Hobbies updatedHobby)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Hobby ID is required");
            }

            var hobby = _context.Hobbies.Find(id);
            if (hobby == null)
            {
                return NotFound("Hobby not found");
            }

            hobby.Name = updatedHobby.Name;
            hobby.Description = updatedHobby.Description;
            hobby.HobbiesId = updatedHobby.HobbiesId;

            _context.Hobbies.Update(hobby);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return BadRequest("Hobby ID is required");
                }

                var hobby = _context.Hobbies.Find(id);
                if (hobby == null)
                {
                    return NotFound("Hobby not found");
                }

                _context.Hobbies.Remove(hobby);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting hobby");
                return StatusCode(500, "Internal server error");
            }
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
