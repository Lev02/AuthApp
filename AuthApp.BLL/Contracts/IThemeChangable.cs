using AuthApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.BLL.Contracts
{
    public interface IThemeChangable
    {
        Task ChangeThemeAsync(ThemeType themeType);

        ThemeType CurrentThemeType { get; }
    }
}
