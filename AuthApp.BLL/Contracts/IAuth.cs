using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.BLL.Contracts
{
    public interface IAuth
    {
        Task LogInAsync(string login, string password);
        Task LogOutAsync();
    }
}
