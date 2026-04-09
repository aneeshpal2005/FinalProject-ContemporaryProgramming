using FinalProject_ContemporaryProgramming.Data;
using FinalProject_ContemporaryProgramming.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_ContemporaryProgramming.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController
    {
        private readonly DefaultContext _context;

        public TeamMemberController(DefaultContext context)
        {
            _context = context;
        }

        public IEnumerable<TeamMember> Get()
        {
            return _context.TeamMember.ToList();
        }
    }
}
