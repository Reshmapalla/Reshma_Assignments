using JeansAppAPI.Entities;
using JeansAppAPI.Models;
using JeansAppAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JeansAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        // Constructor to inject the IUserRepository and IConfiguration dependencies
        public AuthenticateController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        // GET: api/Authenticate/GetAllUsers
        // Asynchronously retrieves all users
        [Authorize(Roles ="Admin")]
        [HttpGet, Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                // Call the repository to fetch all users asynchronously
                var users = await _userRepository.GetAllUsers();

                // Return the users with status 200 OK
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                Console.WriteLine($"An error occurred while fetching users: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Authenticate/Registration
        // Asynchronously registers a new user
        [Authorize(Roles ="Admin,Customer")]
        [HttpPost, Route("Registration")]

        public async Task<IActionResult> Add([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Generate a unique UserId
                    user.UserId = "U" + new Random().Next(1000, 9999);

                    // Call the repository to register the user asynchronously
                    await _userRepository.Register(user);

                    // Return the registered user with status 201 Created
                    return StatusCode(201, user);
                }
                else
                {
                    return BadRequest("Enter valid details");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Authenticate/ValidUser
        // Asynchronously validates a user by email and password
        [Authorize(Roles = "Admin,Customer")]
        [HttpPost, Route("ValidUser")]
        public async Task<IActionResult> ValidUser([FromBody] Login login)
        {
            try
            {
                AuthResponse authResponse = null;
                var user = await _userRepository.ValidUser(login.Email, login.Password);

                if (user != null)
                {
                    authResponse = new AuthResponse
                    {
                        UserId = user.UserId,
                        Role = user.Role,
                        UserName = user.Name,
                        Mobile = user.Mobile,
                        Token = GetToken(user),
                    };

                    // Return the AuthResponse with status 200 OK
                    return Ok(authResponse);
                }
                else
                {
                    // Return a 404 Not Found if the user is not found
                    return NotFound("Invalid email or password");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                Console.WriteLine($"An error occurred during user validation: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Authenticate/DeleteUser
        // Asynchronously deletes a user by ID
        [Authorize(Roles = "Admin,Customer")]
        [HttpDelete, Route("DeleteUser")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            try
            {
                // Call the repository to delete the user asynchronously
                await _userRepository.Delete(id);

                // Return the deleted user ID with status 200 OK
                return Ok(new { UserId = id });
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Authenticate/EditUser
        // Asynchronously updates an existing user
        [Authorize(Roles = "Admin,Customer")]
        [HttpPut, Route("EditUser")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                // Return a 400 Bad Request if the model state is invalid
                return BadRequest("Enter valid details");
            }

            try
            {
                // Call the repository to update the user asynchronously
                await _userRepository.Update(user);

                // Return the updated user with status 200 OK
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                Console.WriteLine($"An error occurred while updating the user: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // Generates a JWT token for the authenticated user
        private string GetToken(User user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            // Header section
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );

            // Payload section
            var subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            });

            var expires = DateTime.UtcNow.AddMinutes(10); // Token will expire after 10 minutes

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            // Generate token using tokenDescriptor
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}


