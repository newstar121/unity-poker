using CardGameConsole.Properties;
using PokerSessionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole.Menus
{
    public class TutorialMenu
    {
        string[] _pages;
        int _currentPageIndex;

        public TutorialMenu()
        {
            _pages = new string[] 
            {
                Resources.TutorialIntroductionContent,
                Resources.TutorialBettingContent,
                Resources.TutorialShowdownContent,
                Resources.TutorialHandsContent
            };

            _currentPageIndex = 0;
        }

        public void Open()
        {
            Console.Clear();
            GraphicsHelper.SetConsoleColor();

            Console.WriteLine(_pages[_currentPageIndex]);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (_currentPageIndex == 0)
                                return;

                            _currentPageIndex--;
                            Console.Clear();
                            Console.WriteLine(_pages[_currentPageIndex]);
                            break;

                        case ConsoleKey.RightArrow:
                            if (_currentPageIndex == _pages.Length - 1)
                                continue;

                            _currentPageIndex++;
                            Console.Clear();
                            Console.WriteLine(_pages[_currentPageIndex]);
                            break;

                        case ConsoleKey.Escape:
                            return;
                    }

                    
                }
            }
        }

    }
}
