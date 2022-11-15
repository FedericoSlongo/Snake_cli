using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Get_to_the_exit
{
    internal class drawning
    {
        //Position of the player
        public int x_plyr = 10, y_plyr = 12;
        //Position of the box
        public int[] x_boxs, y_boxs;
        //Position of the box
        public int[] x_pres_plt, y_pres_plt;
        //Position of the walls
        public int[] x_wall, y_wall;
        //Position of the door
        public int x_door = 7, y_door = 20;
        //If the door is open it's true
        public bool door_open = false;

        //When you create the class you it creates the amounts of boxes and pressure plates neccesary
        public drawning(int am_box_pre, int am_of_wall)
        {
            x_boxs = new int[am_box_pre];
            x_pres_plt = new int[am_box_pre];
            y_boxs = new int[am_box_pre];
            y_pres_plt = new int[am_box_pre];
            x_wall = new int[am_of_wall];
            y_wall = new int[am_of_wall];
        }
        //Drawns cube at x = 0; y = 0;;
        public void draw_cube()
        {
            //Draws X
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition (i, 0);
                Console.Write("■");
            }
            //Drawn Y
            for (int j = 0; j < 15; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write("■");
            }
            for (int j = 0; j < 15; j++)
            {
                Console.SetCursorPosition(20, j);
                Console.Write("■");
            }
            //Draws X
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(i, 15);
                Console.Write("■");
            }
            if (door_open)
            {
                Console.SetCursorPosition(x_door, y_door);
                Console.Write(" ");
            }
        }
        //Draws cube at the specified points
        public void draw_cube(int lunghezza, int altezza)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(lunghezza + i, altezza);
                Console.Write("■");
            }
            for (int j = 0; j < 15; j++)
            {
                Console.SetCursorPosition(lunghezza, altezza + j);
                Console.Write("■");
            }
            for (int j = 0; j < 15; j++)
            {
                Console.SetCursorPosition(lunghezza + 20, altezza + j);
                Console.Write("■");
            }
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(lunghezza + i, altezza + 15);
                Console.Write("■");
            }
            if (door_open)
            {
                Console.SetCursorPosition(x_door, y_door);
                Console.Write(" ");
            }
        }
        //Draws player
        public void draw_player()
        {
            Console.SetCursorPosition(x_plyr, y_plyr);
            Console.Write("*");
        }
        //Draws boxes
        public void draw_boxes()
        {
            for (int i = 0; i < x_boxs.Length; i++)
            {
                Console.SetCursorPosition(x_boxs[i], y_boxs[i]);
                Console.Write("▢");
            }
        }
        //Draws boxes
        public void draw_pres()
        {
            for (int i = 0; i < x_boxs.Length; i++)
            {
                Console.SetCursorPosition(x_pres_plt[i], y_pres_plt[i]);
                Console.Write("●");
            }
        }
        //Drawing walls be like
        public void draw_walls()
        {
            for (int i = 0; i < x_wall.Length; i++)
            {
                Console.SetCursorPosition(x_wall[i], y_wall[i]);
                Console.Write("■");
            }
        }
        //Checks if the player is inside a wall
        public bool isValid(int x, int y)
        {
            for (int i = 0; i < x_wall.Length; i++)
                if (!((x_plyr + x == x_wall[i]) && (y_plyr + y == y_wall[i])))
                    return false;
            return true;
        }

        //Checks if the player as exited
        public bool asExited()
        {
            if (!((x_plyr == x_door) && (y_plyr == y_door)))
                vicory_scree();
            return false;
        }
        //Prints Win screen
        public bool vicory_scree()
        {
            Console.Clear();
            string vict = "■■■■■■■■■■■■■■■■■■■■■";
            int screen_height = (Console.WindowHeight / 2) - 1, screen_width = (Console.WindowWidth / 2) - vict.Length / 2;
            Console.SetCursorPosition(screen_width, screen_height);
            Console.Write(vict);
            screen_height++;
            vict = "■■ !!! YOU WON !!! ■■";
            Console.SetCursorPosition(screen_width, screen_height);
            Console.Write(vict);
            screen_height++;
            vict = "■■■■■■■■■■■■■■■■■■■■■";
            Console.SetCursorPosition(screen_width, screen_height);
            Console.Write(vict);
            return true;
        }
        //Calls all drawing functions
        public void draw_all()
        {
            Console.Clear();
            draw_cube();
            draw_walls();
            draw_pres();
            draw_boxes();
            draw_player();
        }

    }
}
