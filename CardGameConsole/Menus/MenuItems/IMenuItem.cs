using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole.Menus.MenuItems
{
    /// <summary>
    /// Contains functionality for menu items.
    /// </summary>
    public interface IMenuItem
    {
        int X { get; set; }
        int Y { get; set; }

        void Select();
    }
}
