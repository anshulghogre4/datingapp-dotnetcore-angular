

using API.Data;
using API.Entities;
    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{


    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //_context.Users.ToList(); use previusly when it was not async
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> GetUser(int Id)
        {
            return await _context.Users.FindAsync(Id);


        }


    }
}