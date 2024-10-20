using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.BLL.Contracts
{
    interface ILangChangable
    {
        Task ChangeLangAsync(System.Globalization.CultureTypes cultureType);
    }
}
