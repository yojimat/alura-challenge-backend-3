using Alura_Challenge_Backend_3.Models;

namespace Alura_Challenge_Backend_3.Data.Interfaces;

public interface IAuthService
{
    Task Login(UserLoginViewModel userLogin);
    Task Register(UserRegisterViewModel userRegister);
    Task DoLogin();
    Task Logout();
}

