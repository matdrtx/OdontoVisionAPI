
using OdontoVision.Application.DTOs;
public interface IUserService
{
    AuthResult Register(RegisterDto dto);
    AuthResult Login(LoginDto dto);
}
