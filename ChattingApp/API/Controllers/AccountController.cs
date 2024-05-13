using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class AccountController : BaseApiController
    {
        public readonly DataContext context;
        public AccountController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDTOs registerDTOs)
        {
            if (await userExist(registerDTOs.userName)) { return BadRequest("Users Exist"); }
            // the random value return from this method will be our salt
            using var hmac = new HMACSHA512();

            var newUser = new User
            {
                Name = registerDTOs.userName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTOs.password)),
                PasswordSalt = hmac.Key
            };

            context.DataUsers.Add(newUser);

            await context.SaveChangesAsync();

            return newUser;
        }
        private async Task<bool> userExist(string username)
        {
            return await context.DataUsers.AnyAsync(x => x.Name == username);
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> login (LoginDTO loginDTO){
            var user = await context.DataUsers.SingleOrDefaultAsync(x => x.Name == loginDTO.username);
            if (user == null) { return Unauthorized("invalid Username or Pasword");}
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.password));
            for (int i = 0; i < computedPass.Length; i++) {
                if (computedPass[i] != user.PasswordHash[i])
                return Unauthorized("invalid Username or Pasword");
            }
            return user;
        }
    }
}

