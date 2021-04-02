using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Real_Project
{
    public class Command
    {
        #region help
        //  Вывод всех возможных команд
        public static void Help()
        {
            Console.WriteLine("\nКоманда\t\t\tОписание\n");
            Console.WriteLine("show disk\t\tИнформация о диске");
            Console.WriteLine("\nshow catalog\t\tИнформация о текущем каталоге");
            Console.WriteLine("create catalog\t\tСоздание каталога");
            Console.WriteLine("get info catalog\tПолучение информации о характеристиках каталога");
            Console.WriteLine("log in catalog\t\tВход в каталог");
            Console.WriteLine("leave catalog\t\tВыход из каталога");
            Console.WriteLine("delete catalog\t\tУдаление каталога\n");
            Console.WriteLine("\nshow file\t\tПоказать содержимое файла");
            Console.WriteLine("create file\t\tСоздание файла");
            Console.WriteLine("get info file\t\tПолучение информации о файле");
            Console.WriteLine("move file\t\tПеремещение файла");
            Console.WriteLine("copy file\t\tКопирование файла");
            Console.WriteLine("delete file\t\tУдаление файла\n");
            Console.WriteLine("exit\t\t\tВыход из программы");
            Console.WriteLine("Ctr+C\t\t\tЭкстренный выход из программы");
        }
        #endregion

        //  Информация о Дисках
        public static void Disk_Show(string path)
        {
                //  Создание экземпляра класса DriveInfo
            DriveInfo[] drives = DriveInfo.GetDrives();
                //  Вывод информации о дисках
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"\nОбъем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Диск не готов");
            }
            Console.WriteLine();
        }

            //  Информация о содержимом каталога
        public static void Show_Catalog(string path)
        {
            //  Проверка существования каталога по указанному пути
            if (Directory.Exists(path))
            {
                Console.WriteLine("\nПодкаталоги:");
                string[] dirs = Directory.GetDirectories(path);
                //  Вывод содержащихся в текущем каталоге подкаталогов
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
            }
            else
                Console.WriteLine("Каталог с заданным именем не существует");
        }

            //  Показ всех файлов в текущем каталоге
        public static void Show_File(string path)
        {
                //  Проверка существования указанного пути
            if (Directory.Exists(path))
            {
                Console.WriteLine("\nФайлы:");
                string[] files = Directory.GetFiles(path);
                    //  Вывод всех файлов в текущем каталоге
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }
            //  Создание нового каталога
        public static void Create_Catalog(string path)
        {
                //  Создание экземпляра класса DirectoryInfo
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            //  Проверка NE существования каталога по указанному пути
            if (!dirInfo.Exists)
            {
                //  Создание подкаталога в указанном каталоге
                dirInfo.Create();
                Console.WriteLine("\nВведите название нового каталога");
                string subpath = Console.ReadLine();
                dirInfo.CreateSubdirectory(subpath);
                Console.WriteLine("Каталог успешно создана.");
            }
            else
                Console.WriteLine("Каталог с таким именем уже существует");
            
        }

            //  Создание нового файла
        public static void Create_File(string path)
        {
                //  Ввод имени нового файла
            Console.WriteLine("\nВведите имя файла");
            string filename=Console.ReadLine();
            path = path + filename;
                //  Создание экземпляра класа FileInfo
            FileInfo file = new FileInfo(path);
            //  Проверка НЕ существования файла по указанному пути 
            if (!file.Exists)
            {
                //  Создание файла по указанному пути
                File.Create(path);
                Console.WriteLine("Файл успешно создан");
            }
            else
                Console.WriteLine("Не удалось создать файл, так как он уже существует");
        }

            //  Вход в каталог
        public static void Log_In_Catalog(ref string path)
        {
                //  Определение имени каталога в который выполнится вход
            Console.WriteLine("\nВведите папку, в которую выполнится вход");
            string subpath = Console.ReadLine();
            string new_path = path + subpath + "\\";
                //  Проверка на существование каталога по указанному пути
            if (Directory.Exists(new_path))
            {
                path = new_path;
                Console.WriteLine("Вход успешно выполнен");
            }
            else
                Console.WriteLine("Путь не найден");
        }
        
            //  Выделение подстроки из строки пути
        private static string SubPathDel(ref string path, string subpath)
        {
            int n = path.IndexOf(subpath);
            path=path.Remove(n, subpath.Length);
            return path;
        }

            //  Выход из каталога
        public static void Leave_Catalog(ref string path)
        {
            string part_of_path = "";
            int count = 1;
            for (int i = path.Length-1; i != 1; i--)
            {
                if (path[i-1] == '\\')
                {
                    part_of_path=path.Substring(i, count);
                    path = SubPathDel(ref path,part_of_path);
                    break;
                }
                count++;
            }
        }

        //  Получение информации о характеристиках каталога
        public static void Get_Info_Catalog(string path)
        {
                //  Определение имени каталога, о котором будет получена ифнормация
            Console.WriteLine();
            Console.WriteLine("Введиет имя каталога");
            string name = Console.ReadLine();
            string dirName = path + name;
                //  Создание экземляра класса DirectoryInfo
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                //  Вывод информации о каталоге
            Console.WriteLine($"\nНазвание каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
        }
            
            //  Получение информации о файле
        public static void Get_Info_File(string path)
        {
                //  Определение имени каталога, о котором будет получена ифнормация
            Console.WriteLine("\nВведите имя файла");
            string filename = Console.ReadLine();
            path = path + filename;
                //  Создание экземляра класса FileInfo
            FileInfo file = new FileInfo(path);
            //  Определение существования файла, по указанному пути
            if (file.Exists)
            {
                Console.WriteLine("\nИмя файла: {0}", file.Name);
                Console.WriteLine("Время создания: {0}", file.CreationTime);
                Console.WriteLine("Размер: {0}", file.Length);
            }
            else
                Console.WriteLine("Указанный файл не существует");
        }

            //  Перемещение файла
        public static void File_Move(string path)
        {
                //  Определение имени файла, который будет перемещён
            Console.WriteLine("\nВведите файл, который будет перемещён");
            string filename = Console.ReadLine();
            path += filename;
                //  Определение нового пути, по которому будет перемещён файл
            Console.WriteLine("Введите новый путь к файлу");
            string newpath = Console.ReadLine();
            newpath = newpath +"\\" + filename;
                //  Создание экземпляра класса FileInfo
            FileInfo file = new FileInfo(path);
            //  Определение существования файла по начальному пути
            if (file.Exists)
            {
                //  Перемещение файла по новому пути
                file.MoveTo(newpath);
                Console.WriteLine("Перемещение файла успешно выполнено");
            }
            else
                Console.WriteLine("Перемещаемый файл не существует");
        }

            //Копирование файла
        public static void File_Copy(string path)
        {
                //  Переменная ответа пользователя на перезапись файла
            string answer = "";
                //  Выбор файл, который будет скопирован
            Console.WriteLine("\nВведите файл, который будет скопирован");
            string filename = Console.ReadLine();
            path += filename;
                //  Определения пути для компирования файла
            Console.WriteLine("Введите новый путь, по которому будет скопирован файл");
            string newPath = Console.ReadLine();
            newPath += filename;
                //  Экземпляр класса FileInfo
            FileInfo file = new FileInfo(path);
            //  Получение ответа пользователя по перезаписи файла
            Console.WriteLine("Перезаписать файл?(yes/no)");
            while ((answer != "yes") || (answer != "no"))
                answer = Console.ReadLine();
                //  Копирование файла по новому пути, c(yes)/без(no) перезаписью/и
            switch (answer)
            {
                case "yes":file.CopyTo(newPath, true);break;
                case "no": file.CopyTo(newPath, false); break;
            }
        }

            //  Удаление каталога
        public static void Delete_Catalog(string path)
        {
                //  Выбор имени каталога, который будет удалён
            Console.WriteLine("\nВведите имя удаляемого каталога");
            string Name = Console.ReadLine();
            string dirName = path + Name;
            if ((dirName != "D:\\") && (dirName != "C:\\"))
            {
                try
                {
                    //  Создание экземпляра класса DirectoryInfo
                    DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                    //  Удаление каталога
                    dirInfo.Delete(true);
                    Console.WriteLine("Каталог удален");
                }
                //  Обработка исключения
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else Console.WriteLine("Удаление корневой папки невозможно");
        }

            //  Удаление файла
        public static void Delete_File(string path)
        {
                //  Выбор файла, который будет удалён
            Console.WriteLine("\nВведите имя файла");
            string filename = Console.ReadLine();
            path = path + filename;
                //  Создание экземпляра класса FileInfo
            FileInfo file = new FileInfo(path);
            //  Проверка существования файла по указанному пути
            if (file.Exists)
            {
                //  Удаление файла по указанному пути
                File.Delete(path);
                Console.WriteLine("Файл успешно удалён");
            }
            else
                Console.WriteLine("Файл не найден");
        }


    }
}
