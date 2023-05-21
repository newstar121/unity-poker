using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole.Menus.MenuItems
{
    public class TutorialItem : IMenuItem
    {
        public int X { get; set; }
        public int Y { get; set; }

        public TutorialItem(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Select()
        {
            new TutorialMenu().Open();
        }
    }
}
