using E_Commerce_API.Data;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce_API.Repo.Implementation
{
    public class AuthRepo:IAuthRepo
    {
        private readonly App_Database_Context _db;
        private readonly IConfiguration _configuration;
        public AuthRepo (App_Database_Context db,IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<string> Login(AuthLoginDTO dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x=>x.Email == dto.Email);
            if (user == null)
                return null;

            if(user.Password == dto.Password)
                return TokenGanertor(user);

            return null;
        }

        public async Task<bool> Register(AuthRegisterDTO dto)
        {
            var ExistingEmail = await _db.Users.AnyAsync(x => x.Email == dto.Email);
            if(ExistingEmail) 
                return false;
            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                Name = dto.Name,
                Role = "Customer"
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }


        private string TokenGanertor(User user)
        {
            var Cliams = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var SigningCrad = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var JWTToken = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["JWT:ExpireInHours"])),
                    claims: Cliams,
                    signingCredentials : SigningCrad
                );
            var token = new JwtSecurityTokenHandler().WriteToken(JWTToken);
            return token;
        }
    }
}
