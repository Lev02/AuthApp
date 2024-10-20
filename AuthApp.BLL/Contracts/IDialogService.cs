using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.BLL.Contracts
{
    public interface IDialogService
    {
        void ShowContent(object content, string title);
    }
}
