using BCrypt.Net;
using System;

using OdontoVision.Application.DTOs;
using System.Linq;
using System.Collections.Generic;
using OdontoVision.Application.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

public class UserService : IUserService
{
    private readonly IConfiguration _config;
    private static List<User> users = new();

    public UserService(IConfiguration config)
    {
        _config = config;
    }

    public AuthResult Register(RegisterDto dto)
    {
        if (users.Any(u => u.Email == dto.Email))
            return new AuthResult { Success = false, Message = "Usuário já existe." };

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "Dentist"
        };

        users.Add(user);
        return new AuthResult { Success = true, Token = GenerateToken(user) };
    }

    public AuthResult Login(LoginDto dto)
    {
        var user = users.FirstOrDefault(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return new AuthResult { Success = false, Message = "Credenciais inválidas." };

        return new AuthResult { Success = true, Token = GenerateToken(user) };
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
