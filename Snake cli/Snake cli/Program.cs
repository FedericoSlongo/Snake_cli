using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake_cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int x = 0, y = 0, x_punt = 0, y_punt = 0, snake_lenght = 1;
            bool dead = false;
            string tasto;
            Console.WriteLine("*");
            x_punt = random.Next(0, 111);
            y_punt = random.Next(0, 16);

            while (!dead)
            {
                tasto = Console.ReadLine();
                switch (tasto)
                {
                    case "a":
                        x--;
                        break;
                    case "s":
                        y++;
                        break;
                    case "d":
                        x++;
                        break;
                    case "w":
                        y--;
                        break;
                    default:
                        Console.WriteLine("ERORE");
                        break;
                }
                //Only allowed snake position higher than 0
                if (x < 0 || x > Console.WindowWidth - 10)
                    break;
                if (y < 0 || y > Console.WindowHeight - 10)
                    break;

                Console.Clear();
                //Apple generation and check
                if ((x == x_punt) && (y == y_punt))
                {
                    snake_lenght++;
                    x_punt = random.Next(0, 111);
                    y_punt = random.Next(0, 16);
                }

                //Printing the apple
                for (int i = 0; i < y_punt; i++)
                    Console.WriteLine("");
                for (int i = 0; i < x_punt; i++)
                    Console.Write(" ");
                Console.Write("O");

                //Printing the snake
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < snake_lenght; i++)
                    Console.Write("*");
                
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
            for (int i = 0; i < Console.WindowWidth ; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }
    }
}
