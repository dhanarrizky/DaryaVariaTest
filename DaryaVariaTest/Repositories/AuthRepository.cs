using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DaryaVariaTest.Repositories;

public class AuthRepository : IAuthRepository {
    private readonly DaryaVariaAppContext _context;
    public AuthRepository(DaryaVariaAppContext context){
        _context = context;
    }

    public LoginAuth GetLoginAuth(string usernameoremail) {
        return _context.LoginAuths.FirstOrDefault(x =>
            x.Username.Equals(usernameoremail) ||
            x.Email.Equals(usernameoremail)) ??
            throw new InvalidOperationException("Username or email not found");
    }

}