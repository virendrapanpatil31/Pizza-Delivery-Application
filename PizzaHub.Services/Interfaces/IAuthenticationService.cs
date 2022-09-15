using PizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool CreateUser(User user, string password);
        Task<bool> SignOut();
        User AuthenticateUser(string Username, string Password);
        User GetUser(string Username);
    }
}
