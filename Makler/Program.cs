﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Makler
{
    class Program
    {
        enum MenuOption { AddApartment = 1, SearchApartments, ShowAllApartments, Exit }

        static void Main(string[] args)
        {
            ActionsFlats actionsFlats = new ActionsFlats();
            MenuOption option;

            while (true)
            {
                WriteLine("\nВыберите действие:");
                WriteLine(" 1. Добавить квартиру");
                WriteLine(" 2. Поиск вариантов квартир");
                WriteLine(" 3. Вывести всю картотеку квартир");
                WriteLine(" 4. Выйти");

                ConsoleKeyInfo keyInfo = ReadKey(intercept: true);
                bool isValidInput = Enum.TryParse(keyInfo.KeyChar.ToString(), out option);

                if (!isValidInput || !Enum.IsDefined(typeof(MenuOption), option))
                {
                    WriteLine("\nНекорректный ввод. Пожалуйста, выберите опцию из списка.");
                    continue;
                }
                Clear();
                WriteLine();

                switch (option)
                {
                    case MenuOption.AddApartment:
                        actionsFlats.AddFlat();
                        Clear();
            
                        break;

                    case MenuOption.SearchApartments:
                        actionsFlats.WriteFlat();
                        break;

                    case MenuOption.ShowAllApartments:
                        
                        actionsFlats.Info();
                        break;

                    case MenuOption.Exit:
                        WriteLine("Выход из программы.");
                        return;
                }
            }
        }
    }
}