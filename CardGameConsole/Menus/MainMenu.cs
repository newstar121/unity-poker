using CardGameConsole.Menus.MenuItems;
using CardGameConsole.Properties;
using PokerSessionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole.Menus
{
    public class MainMenu
    {
        int _currentItemIndex;
        IMenuItem[] _menuItems;

        public MainMenu()
        {
            _currentItemIndex = 0;
            _menuItems = new IMenuItem[] { new StartGameItem(48, 11), new TutorialItem(48, 13), new ExitGameItem(48, 15) };
        }

        public void Open()
        {
            Console.Clear();
            GraphicsHelper.SetConsoleColor();

            bool optionSelected = false;
            Console.CursorVisible = false;
            Console.WriteLine(Resources.MainMenuContent);

            Console.CursorTop = _menuItems[_currentItemIndex].Y;
            GraphicsHelper.DrawSelector(_menuItems[_currentItemIndex].X, 15);

            while (!optionSelected)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            GraphicsHelper.EraseSelector(_menuItems[_currentItemIndex].X, 15);
                            _currentItemIndex--;

                            if (_currentItemIndex < 0)
                                _currentItemIndex = _menuItems.Length - 1;

                            break;

                        case ConsoleKey.DownArrow:
                            GraphicsHelper.EraseSelector(_menuItems[_currentItemIndex].X, 15);
                            _currentItemIndex++;

                            if (_currentItemIndex > _menuItems.Length - 1)
                                _currentItemIndex = 0;

                            break;

                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Enter:
                            optionSelected = true;
                            break;

                    }

                    Console.CursorTop = _menuItems[_currentItemIndex].Y;
                    GraphicsHelper.DrawSelector(_menuItems[_currentItemIndex].X, 15);
                }
            }

            while (_currentItemIndex != -1)
            {
                _menuItems[_currentItemIndex].Select();
                Open();
            }
        }
    }
}
