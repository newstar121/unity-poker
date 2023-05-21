using CardGameConsole.Properties;
using PokerSessionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGameConsole.Menus.MenuItems
{
    public class ExitGameItem : IMenuItem
    {
        bool _exitGame;
        public int X { get; set; }
        public int Y { get; set; }

        public ExitGameItem(int x, int y)
        {
            _exitGame = false;
            this.X = x;
            this.Y = y;
        }

        public void Select()
        {
            Console.Clear();
            Console.WriteLine(Resources.ExitMenuContent);
            bool optionSelected = false;
            Console.CursorTop = 11;
            GraphicsHelper.DrawSelector(59, 5);

            while (!optionSelected)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            _exitGame = true;
                            GraphicsHelper.EraseSelector(59, 5);
                            GraphicsHelper.DrawSelector(46, 6);
                            break;

                        case ConsoleKey.RightArrow:
                            _exitGame = false;
                            GraphicsHelper.EraseSelector(46, 6);
                            GraphicsHelper.DrawSelector(59, 5);
                            break;

                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Enter:
                            optionSelected = true;
                            break;

                        case ConsoleKey.Escape:
                            return;
                    }

                    
                }
            }

            if (_exitGame)
                Environment.Exit(0);
        }

    }
}
