using AuthApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user);
        Task<bool> LoginAsync(string username, string password);
        Task<bool> LogoutAsync();
        Task<User> GetUserByLoginAsync(string username);
    }
}
