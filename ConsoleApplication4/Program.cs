using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {

            System.IO.StreamWriter csvfile = new System.IO.StreamWriter("D:\\Users\\Darren Coutts\\Desktop\\A Search\\map_details.csv");

            int[] sizes = new int[] { 5, 10, 15, 20, 40, 50, 75, 100, 150, 200, 250, 300, 400, 500, 750 };

            int dirs = 4;
            int[] dx = { 1, 0, -1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            int map_size = 5;
            int m;
            int n;
            int xA = 0, yA = 0, xB = 0, yB = 0;

            csvfile.WriteLine("MapSize,MapID,ManhatDistance,SQRDistance,PathLen,ExploredNodes");

            String line;

            foreach (int size in sizes)
            {
                for (int id = 0; id < 20; id++)
                {
                    Console.WriteLine(size);

                    map_size = size;

                    int row = 0;
                    n = m = 2 * map_size + 2;

                    int[,] the_map = new int[n, m];

                    // Read the file and display it line by line.
                    System.IO.StreamReader file =
                       new System.IO.StreamReader("D:\\Users\\Darren Coutts\\Desktop\\A Search\\maze" + size + "_"+id+".mz");
                    while ((line = file.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);

                        for (int col = 0; col < line.ToCharArray().Length; col++)
                        {
                            int x = 0;
                            String value = line[col].ToString();
                            if (value == ".")
                            {
                                x = 0;
                            }
                            else if (value == ("+"))
                            {
                                x = 1;
                            }
                            else if (value == ("S"))
                            {
                                x = 2;
                                xA = col;
                                yA = row;

                            }
                            else if (value == ("F"))
                            {
                                x = 4;
                                xB = col;
                                yB = row;
                            }

                            the_map[row, col] = x;
                        }

                        row++;
                    }

                    file.Close();

                    String Results = null;
                    long total = 0;

                    //for (int run = 0; run < 10; run++)
                    //{
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        Search s = new Search(the_map, m, n, dirs, dx, dy, xA, yA, xB, yB);
                        watch.Stop();

                        int manhattanDistance = Math.Abs(xB - xA) + Math.Abs(yB - yA);
                        double distance = Math.Sqrt(Math.Pow(xB - xA, 2) + Math.Pow(yB - yA, 2));
                        int pathLength = s.path.Length;
                        int exploredNodes = s.closednodecount;

                       // Results = Results + " , " + (watch.ElapsedMilliseconds);
                       // total = total + (watch.ElapsedMilliseconds);
                    //}

                    //long average = total / 10;
                    csvfile.WriteLine(map_size + "," + id + "," + manhattanDistance + "," + ", " + distance + "," + pathLength + "," + exploredNodes);
                    //Console.WriteLine(average);


                }

            }
            csvfile.Close();
            Console.ReadLine();
        }

    }
}
