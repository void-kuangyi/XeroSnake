using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    public class Style
    {
        public void StyleMaze(int[,] maze)
        {
            System.Console.Clear();

            StringBuilder designedMaze = new StringBuilder();
            //string designedMaze = string.Empty;
            int rowLength = maze.GetLength(0);
            int coloumnLength = maze.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < coloumnLength; j++)
                {
                    designedMaze.Append(StyleMazeElement(maze[i, j]));
                }
                designedMaze.Append(Environment.NewLine);
            }
            Console.Write(designedMaze);

        }
        public string StyleMazeElement(int mazeElement)
        {
            
            switch (mazeElement)
            {
                case 0:
                    return " ";
                case 1:
                    return "█";

                case 2:
                    return "Ö";

                case 3:
                    return "▓";

                case 4:
                    return "\u058D";

                case 5:
                    return "ô";

                case 6:
                    return "G";

                default:
                    throw new System.Exception("Invalid Game Element Processed!");
            }
        }

        public static void menuImage()
        {
            Console.WriteLine("");
            Console.WriteLine("         uB@@@B@B@Bu  M@L       8@u    :B@B@B@B.    S@P       F@B  UBMB@B@B@B@@@");
            Console.WriteLine("       77v1j22u22Uqi  @BL       B@5  r771uU1Uu27vi  0BG     JvjSu  U@MLuUU2u5uS1");
            Console.WriteLine("       @Bi            M@r       G@j  @B5       ZBO  F@X    :@@:    u@E          ");
            Console.WriteLine("       B@:            MBMB@     8Bu  G@L       F@S  SBF  0@M       J@P          ");
            Console.WriteLine("       @BFvYYuY2J     O@277u2i  Z@J  ZBX7jLuYYr0BS  5@N7L77r       uB8rJLuLuF:  ");
            Console.WriteLine("       B@@@@@@@B@     BBr  B@2  E@u  E@M@B@B@B@O@5  FBMB@,         Y@M@B@@@B@Y  ");
            Console.WriteLine("                 @@L  M@7    7B@M@Y  GBY       FBk  5@1  GB@       uB0          ");
            Console.WriteLine("                 B@L  BBv    .7:8Bu  E@J       k@F  SBX  :v7Sq,    J@q          ");
            Console.WriteLine("                 8B7  M@v       Z@j  8B2       0BX  k@q     B@r..  uBG          ");
            Console.WriteLine("       B@@@B@B@B@2$   @B2       @BP  B@q       M@O  OBM       ZB@  k@B@B@B@@@B@B");
            Console.WriteLine("       ri:ii:i:ri7    ir.       :r,  ii:       :i:  :r:       ,7i  ,i::i:i:ii:;;");
            Console.WriteLine("");
            Console.WriteLine("                    ,,....,.........,.......,.,.......,.,.., ");
            Console.WriteLine("                    @@@@B@B@B@B@B@B@B@B@B@@@B@B@B@B@B@B@B@B@Y");
            Console.WriteLine("                    ..... . ....... . .. .... . .. .. .   MB7");
            Console.WriteLine("                                                          O@r");
            Console.WriteLine("                                                          MB7");
            Console.WriteLine("                                        B@B       U@B@B@B@B@L");
            Console.WriteLine("                                        2BO       rN52FUFuY1:");
            Console.WriteLine("");
            Console.WriteLine("Please select a game mode:");
            Console.WriteLine("1. Single Player");

        }
    }
}
            
