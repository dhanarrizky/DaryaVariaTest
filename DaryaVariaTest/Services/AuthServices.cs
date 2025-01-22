using System.Data;
using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;

namespace DaryaVariaTest.Services;

public class AuthServices {
    public AuthServices(){}

    public void GetAuthentication(LoginViewModels lvm) {
        Console.WriteLine(lvm);
    }
}
