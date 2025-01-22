using System.Data;
using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;

namespace DaryaVariaTest.Services;

public class AuthServices {
    private readonly IAuthRepository _repo;
    public AuthServices(IAuthRepository authRepository){
        _repo = authRepository;
    }

    public LoginAuth Authenticate(LoginViewModels lvm) {
        Console.WriteLine($"{lvm.UsernameOrEmail}");
        Console.WriteLine($"{lvm.Password}");
        try {
            var user = _repo.GetLoginAuth(lvm.UsernameOrEmail);
            var result = BCrypt.Net.BCrypt.Verify(lvm.Password, user.PasswordHash);
            Console.WriteLine($"{result}");
            if (!result) {
                return null;
            }
            return user;
        } catch {
            return null;

        }
    }
}
