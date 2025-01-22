using DaryaVariaTest.Models;

namespace DaryaVariaTest.IRepositories;

public interface IAuthRepository {
    public LoginAuth GetLoginAuth(string usernameoremail);
}