using AuthApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.BLL.Messages
{
    public class UserSignedUpMessage
    {
        public User User { get; }

        public UserSignedUpMessage(User user)
        {
            User = user;
        }
    }
}
