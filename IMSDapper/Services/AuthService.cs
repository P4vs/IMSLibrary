using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Helpers;
using IMSDapper.Model;
using IMSDapper.Repository;
using IMSDapper.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IMSDapper.Services
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _config;

        public AuthService( IConfiguration config)
        {
            _config = config;
        }

        // ✅ REGISTER USER
        public async Task<bool> RegisterUser(LoginRequest request)
        {
            AuthRepository _authRepository = new AuthRepository();
            var existingUser = await _authRepository.GetUserByUsername(request.Username);
            if (existingUser != null) return false; // User already exists

            // ✅ Ensure Role is a valid value ('Admin' or 'User')
            string role = "Staff"; // Default role
            if (!new[] { "WarehouseManager", "Staff", "Admin" }.Contains(role))
                throw new Exception("Invalid role");

            var newUser = new UserModel
            {
                Username = request.Username,
                PasswordHash = PasswordHelper.HashPassword(request.Password),
                Role = role, // ✅ Ensure valid role
                CreatedAt = DateTime.UtcNow
            };

            return await _authRepository.CreateUser(newUser) > 0;
        }

        // ✅ AUTHENTICATE & GENERATE TOKEN
        public async Task<string?> Authenticate(LoginRequest request)
        {
            AuthRepository _authRepository = new AuthRepository();
            var user = await _authRepository.GetUserByUsername(request.Username);
            if (user == null || !PasswordHelper.VerifyPassword(request.Password, user.PasswordHash))
                return null; // Invalid credentials

            return GenerateToken(user);
        }

        // ✅ GENERATE JWT TOKEN
        private string GenerateToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["JwtSettings:ExpiryMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
