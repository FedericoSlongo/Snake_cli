using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> x = new List<int>(), y = new List<int>();
            int x_punt = 0, y_punt = 0, snake_lenght = 1;
            bool dead = false;
            x.Add(1);
            y.Add(1);
            x_punt = random.Next(0, 111);
            y_punt = random.Next(0, 16);
            Console.CursorVisible = false;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\Fart Sounds 1 hour.wav");
            try
            {
                player.Play();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("There no song in the same position as the program\nPress any key to continue");
                Console.ReadKey();
            }
            while (!dead)
            {
                Thread.Sleep(10);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        for (int i = 0; i < snake_lenght - 1; i++)
                            x[i + 1] = x[i];
                        for (int i = 0; i < snake_lenght - 1; i++)
                            y[i + 1] = y[i];
                        x[0]--;
                        break;
                    case ConsoleKey.S:
                        for (int i = 0; i < snake_lenght - 1; i++)
                            x[i + 1] = x[i];
                        for (int i = 0; i < snake_lenght - 1; i++)
                            y[i + 1] = y[i];
                        y[0]++;
                        break;
                    case ConsoleKey.D:
                        for (int i = 0; i < snake_lenght - 1; i++)
                            x[i + 1] = x[i];
                        for (int i = 0; i < snake_lenght - 1; i++)
                            y[i + 1] = y[i];
                        x[0]++;
                        break;
                    case ConsoleKey.W:
                        for (int i = 0; i < snake_lenght - 1; i++)
                            x[i + 1] = x[i];
                        for (int i = 0; i < snake_lenght - 1; i++)
                            y[i + 1] = y[i];
                        y[0]--;
                        break;
                    default:
                        Console.WriteLine("ERORE");
                        break;
                }
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                }
                //Only allowed snake position higher than 0
                if (x[0] < 0 || x[0] > Console.WindowWidth - 5)
                    break;
                if (y[0] < 0 || y[0] > Console.WindowHeight - 5)
                    break;

                Console.Clear();
                //Apple generation and check
                if ((x[0] == x_punt) && (y[0] == y_punt))
                {
                    x.Add(x[snake_lenght - 1]-1);
                    y.Add(y[snake_lenght - 1]-1);
                    snake_lenght++;
                    x_punt = random.Next(2, Console.WindowWidth - 5);
                    y_punt = random.Next(2, Console.WindowHeight - 5);
                }

                //Printing the apple
                Console.SetCursorPosition(x_punt, y_punt);
                Console.Write("O");

                //Printing the snake
                for (int i = 0; i < snake_lenght; i++)
                {
                    if (i == 0)
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write("°");
                        continue;
                    }
                    Console.SetCursorPosition(x[i], y[i]);
                    Console.Write("*");
                }
            } 
            Thread.Sleep(500);
            //When you die :D
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
            }
            Console.Clear();
            string sei_morto = "Get good bro";
            barre();
            int grandezza = (Console.WindowWidth / 2);
            for (int i = 0; i < grandezza - (sei_morto.Length / 2); i++)
                Console.Write(" ");
            Console.WriteLine(sei_morto);
            barre();


            Console.ReadKey();
        }
        static void barre()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }
    }
}
