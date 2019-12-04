using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inpWireLines = System.IO.File.ReadAllLines(@".\..\..\input.txt");

            // not the whole wiring is needed, because only the distance from the center is form interest.
            char[,] playground = new char[1000, 1000];
            FillPlayground(ref playground);
            //PlotPlayground(ref playground);

            // start position (center)
            int xstart = (int)(playground.GetLength(0) / 2);
            int ystart = (int)(playground.GetLength(1) / 2);
            
            // draw wired
            char[] tiles = { 'A', 'B' };    // wire colors
            for(int w = 0; w < 2; w++)
            {
                // start from center
                int xpos = xstart;
                int ypos = ystart;
                // mark center
                playground[xpos, ypos] = 'o';

                string[] path = inpWireLines.ElementAt(w).Split(',');
                foreach (string segment in path)
                {
                    int dist = int.Parse(segment.Substring(1));
                    // doodle some liness
                    switch (segment[0])
                    {
                        case 'R':
                            for(int i = 0; i < dist; i++)
                            {
                                xpos++;
                                FillTile(xpos, ypos, ref playground, tiles[w]);
                            }
                            break;
                        case 'L':
                            for (int i = 0; i < dist; i++)
                            {
                                xpos--;
                                FillTile(xpos, ypos, ref playground, tiles[w]);
                            }
                            break;
                        case 'U':
                            for (int i = 0; i < dist; i++)
                            {
                                ypos++;
                                FillTile(xpos, ypos, ref playground, tiles[w]);
                            }
                            break;
                        case 'D':
                            for (int i = 0; i < dist; i++)
                            {
                                ypos--;
                                FillTile(xpos, ypos, ref playground, tiles[w]);
                            }
                            break;
                    }
                }
            }
            PlotPlayground(ref playground);

            // search for intersections (+)
            List<Position> interPos = new List<Position>();
            for(int x = playground.GetLowerBound(0)+1; x <= playground.GetUpperBound(0)-1; x++)
            {
                for (int y = playground.GetLowerBound(1)+1; y <= playground.GetUpperBound(1)-1; y++)
                {
                    if(playground [x,y] == '+')
                    {
                        interPos.Add(new Position { xpos = x, ypos = y });
                    }
                }
            }

            // get distance from the center to intersections
            Console.WriteLine("Dinstances (pick the smallest):");
            foreach (Position dist in interPos)
            {
                int xdist = 0;
                int ydist = 0;
                if(dist.xpos > xstart)
                {
                    xdist = dist.xpos - xstart;
                }
                else
                {
                    xdist = xstart - dist.xpos;
                }
                if (dist.ypos > ystart)
                {
                    ydist = dist.ypos - ystart;
                }
                else
                {
                    ydist = ystart - dist.ypos;
                }
                Console.WriteLine("Dist x={0},\ty={1},\ttotal {2}", xdist, ydist, xdist + ydist);
            }
    
            Console.WriteLine("END");
            //Console.ReadLine();

        }

        private static void PlotPlayground(ref char[,] playground)
        {
            StringBuilder sb = new StringBuilder();
            for(int y = 0;  y < playground.GetLength(1); y++)
            {
                for (int x = 0; x < playground.GetLength(0); x++)
                {
                    //Console.Write(String.Join("", playground[x, y]));
                    sb.Append(playground[x, y]);
                }
                //Console.WriteLine();
                sb.AppendLine();
            }
            System.IO.File.WriteAllText(@"..\..\output.txt", sb.ToString());
        }

        private static void FillPlayground(ref char[,] playground)
        {
            for (int y = 0; y < playground.GetLength(1); y++)
            {
                for (int x = 0; x < playground.GetLength(0); x++)
                {
                    playground[x, y] = ' ';
                }
            }
        }

        private static void FillTile(int xpos, int ypos, ref char[,] playground, char pattern)
        {
            if (xpos >= playground.GetLength(0)) xpos = playground.GetLength(0) - 1;
            if (xpos < 0) xpos = 0;
            if (ypos >= playground.GetLength(1)) ypos = playground.GetLength(1) - 1;
            if (ypos < 0) ypos = 0;
            if (playground[xpos, ypos] == ' ')
            {
                // plain ground, set mark
                playground[xpos, ypos] = pattern;
            }
            else if (playground[xpos, ypos] == pattern)
            {
                // crossover with the same wirre...ignore
            }
            else
            {
                // crossover with other wire, mark instersection
                playground[xpos, ypos] = '+';
            }
        }

        class Position
        {
            public int xpos;
            public int ypos;
        }
    }
}
