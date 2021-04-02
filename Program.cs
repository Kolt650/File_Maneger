using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Real_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Properties.Settings.Default.Save();
            //  Путь принимается из параметров 
            string path = Properties.Settings.Default.path_config;
                //  Имитатор Командной строки
            string cmd = "";
            //class DirectoryGetParent
                //  Выполнение до ввода команды end
            while (cmd != "end")
            {
                    //  Вывод текущего пути
                Console.WriteLine(path);
                    //  Имитация командной строки
                cmd = Console.ReadLine();
                    //  Обработка запроса
                switch (cmd)
                {
                        //  Выход
                    case "exit" : cmd = "end"; break;
                        //  Вспомогательные команды
                    case "help" : Command.Help(); break;                              //Получения списка комнанд
                        //  Работа с диском
                    case "show disk" : Command.Disk_Show(path); break;                //  Информация о диске
                        //  Работа с каталогами
                    case "show catalog" : Command.Show_Catalog(path); break;         //  Информация о текущей директории
                    case "create catalog" : Command.Create_Catalog(path); break;     //  Создание каталога
                    case "get info catalog" : Command.Get_Info_Catalog(path); break;  //  Получение информации о характеристиках каталога
                    case "log in catalog" : Command.Log_In_Catalog(ref path); break; //  Вход в каталог
                    case "leave catalog" : Command.Leave_Catalog(ref path); break;    //  Выход из каталога
                    case "delete catalog" : Command.Delete_Catalog(path); break;     //  Удаление каталога
                        //  Работа с файлами
                    case "show file" : Command.Show_File(path); break;                //  Показать содержимое файла
                    case "create file" : Command.Create_File(path); break;           //  Создание файла
                    case "get info file" : Command.Get_Info_File(path); break;       //  Получение информации о файле
                    case "move file" : Command.File_Move(path); break;               //  Перемещение файла
                    case "delete file" : Command.Delete_File(path); break;           //  Удаление файла
                        //  Ошибка
                    default : Console.WriteLine("Команда не распознана\nВызовите команду помощи: help"); break;     //  В случае нераспознания команды
                }
                Console.WriteLine();
                Properties.Settings.Default.path_config = path;
                Properties.Settings.Default.Save();
            }
            //Console.ReadKey();
        }
    }
}