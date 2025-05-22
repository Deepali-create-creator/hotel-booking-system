using HotelBookingApp.DTOs;
using HotelBookingApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (existingUser != null)
            {
                return BadRequest(new { status = false, message = "Email is already registered." });
            }

            var user = new User
            {
                Email = model.Email,
                Password = model.Password 
            };

            await _context.Users.AddAsync(user);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return Ok(new { status = true, message = "User registered successfully" });
            }

            return BadRequest(new { status = false, message = "Failed to register user" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return Ok(new { status = false, message = "User not found" });
            }
            else
            {
                return Ok(new { status = true, user = user });
            }
        }
    }
}
