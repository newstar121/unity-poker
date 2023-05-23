/************************
 Author: Asel S.
 Version: 4.5
 ************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameConsole.Menus;
using PokerSessionLibrary;

namespace CardGameConsole
{
    class PokerProgram
    {   
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(120, 25);
            Console.Title = "C# Poker Game v4.5";

            MainMenu mainMenu = new MainMenu();
            mainMenu.Open();

            Console.ReadLine();
        } 

    } 

} 
