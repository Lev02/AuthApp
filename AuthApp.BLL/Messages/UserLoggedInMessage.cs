using AuthApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.BLL.Messages
{
    public class UserLoggedInMessage
    {
        public User User { get; }

        public UserLoggedInMessage(User user) 
        {
            User = user;
        }
    }
}
