using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_1
{
    class Program
    {
       static void S(DirectoryInfo directory, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] fs = directory.GetFileSystemInfos();

            for (int index = 0; index < fs.Length; index++)
            {
                FileSystemInfo fileSystemInfo = fs[index];
                if (index == cursor)
                    Console.BackgroundColor = ConsoleColor.Blue;
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                Console.WriteLine(fileSystemInfo.Name);
                }
            }

        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\PP2");
            int cursor = 0;
            int n = directoryInfo.GetFileSystemInfos().Length;
            S(directoryInfo, cursor);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                        cursor = 0;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                        cursor = n - 1;
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (directoryInfo.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directoryInfo = new DirectoryInfo(directoryInfo.GetFileSystemInfos()[cursor].FullName);
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directoryInfo.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }
                if (keyInfo.Key == ConsoleKey.Escape || (keyInfo.Key == ConsoleKey.Backspace) ) 
                {
                    if (directoryInfo.Parent != null)
                    {
                        directoryInfo = directoryInfo.Parent;
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
                S(directoryInfo, cursor);
            }
        }

       
        }
    }

