using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tower_Of_Hanoi
{
    class Program
    {
        static List<Stack> ColumnsOfGame = new List<Stack>();
        static void Main(string[] aregs)
        {
            Console.WriteLine("  Hello!!\r\n  AutoPlay Ring Mover Game!!!");
            Console.WriteLine("  Please enter the number of columns and rings to create the game");
            Console.WriteLine("\r\n  Note!!! :(Minimum value of columns should be 3 due to game rules \r\n  and Maximum value is 15 because otherwise does not fit in console window.) \r\n\r\n  Columns (3 < C < 15): ");
            Console.Write("  ");
            int NumberOfColumns = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("  Note!!! :(Minimum value of rings should be 2 due to game rules \r\n  and Maximum value is 35 because otherwise does not fit in console window.) \r\n  Ringss (2 < R < 35): ");
            Console.Write("  ");
            int NumberOfRings = Convert.ToInt32(Console.ReadLine());
            CreateGame(NumberOfColumns, NumberOfRings);
            Display(NumberOfColumns, NumberOfRings);
            Console.WriteLine("\r\n  Do you want to Play or want me to solve it?" + "\r\n      1-Play   2-Solve it by computer");
            Console.Write("  ");
            string Choice = Console.ReadLine();
            if (Choice == "1")
                RingMover(NumberOfColumns, NumberOfRings);
            else
                AutoPlay(NumberOfColumns, NumberOfRings);
        }

        private static void CreateGame(int numberOfColumns, int numberOfRings)
        {
            for (int i = 0; i < numberOfColumns; i++)
            {
                Stack NewColumn = new Stack(numberOfRings);
                ColumnsOfGame.Add(NewColumn);
            }
            Random ColumnChoice = new Random();
            int ColumnIndex;
            for (int i = 1; i <= numberOfRings; i++)
            {
                ColumnIndex = ColumnChoice.Next(0, numberOfColumns);
                ColumnsOfGame[ColumnIndex].Push(Convert.ToString(i));
            }
        }
        private static void Display(int numberOfColumns, int numberOfRings)
        {
            string ItemOfColumn;
            Console.Clear();
            Console.WriteLine("  Hello!!\r\n  Ring Mover Game!!!\r\n  You should put all of the numbers in an increasing order in one of the columns.\r\n");
            Console.Write("    ");
            for (int i = 1; i <= numberOfColumns; i++)
            {
                Console.Write("Column" + i + "   ");
            }
            Console.Write("\r\n" + "    ");
            for (int i = 1; i <= numberOfColumns; i++)
            {
                Console.Write("****** " + "   ");
            }
            Console.Write("\r\n" + "    ");
            for (int i = 0; i < numberOfRings; i++)
            {
                for (int k = 0; k < numberOfColumns; k++)
                {
                    if (ColumnsOfGame[k].GetItem(i) == null)
                        ItemOfColumn = "  ";
                    else
                    {
                        if (ColumnsOfGame[k].GetItem(i).Length == 1)
                            ItemOfColumn = ColumnsOfGame[k].GetItem(i) + " ";
                        else
                            ItemOfColumn = ColumnsOfGame[k].GetItem(i);
                    }
                    Console.Write("* " + ItemOfColumn + " *    ");
                }
                Console.Write("\r\n" + "    ");
            }
        }
        private static void AutoPlay(int numberOfColumns, int numberOfRings)
        {
            Display(numberOfColumns, numberOfRings);
            int LocationOne = FindItem(numberOfColumns, numberOfRings, 1);
            while (ColumnsOfGame[LocationOne].GetCount() != 1)
            {
                if(LocationOne==0)
                    ColumnsOfGame[LocationOne + 1].Push(ColumnsOfGame[LocationOne].Pop());
                else
                    ColumnsOfGame[LocationOne - 1].Push(ColumnsOfGame[LocationOne].Pop());
                Display(numberOfColumns, numberOfRings);
                Console.WriteLine("\r\n    Press any key to Continue");
                Console.ReadKey();
            }
            Display(numberOfColumns, numberOfRings);
            for (int i = 2; i <= numberOfRings; i++)
            {
                int Location = FindItem(numberOfColumns, numberOfRings, i);
                while (ColumnsOfGame[Location].Peek()!=Convert.ToString(i))
                {
                    if (Location == 0)
                    {
                        if (Location == 0 && Location + 1 == LocationOne)
                        {
                            ColumnsOfGame[Location + 2].Push(ColumnsOfGame[Location].Pop());
                            Console.WriteLine("\r\n    Press any key to Continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            ColumnsOfGame[Location + 1].Push(ColumnsOfGame[Location].Pop());
                            Console.WriteLine("\r\n    Press any key to Continue");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        if (Location == numberOfColumns - 1 && Location - 1 == LocationOne)
                        {
                            ColumnsOfGame[Location - 2].Push(ColumnsOfGame[Location].Pop());
                            Console.WriteLine("\r\n    Press any key to Continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            ColumnsOfGame[Location - 1].Push(ColumnsOfGame[Location].Pop());
                            Console.WriteLine("\r\n    Press any key to Continue");
                            Console.ReadKey();
                        }
                    }
                    Display(numberOfColumns, numberOfRings);
                }
                Console.WriteLine("\r\n    Press any key to Continue");
                Console.ReadKey();
                ColumnsOfGame[LocationOne].Push(ColumnsOfGame[Location].Pop());
                Display(numberOfColumns, numberOfRings);
            }
            Display(numberOfColumns, numberOfRings);
            Console.WriteLine("\r\n    Finish");
            Console.WriteLine("    Press any key to exit");
            Console.ReadKey();
        }
        private static void RingMover(int numberOfColumns, int numberOfRings)
        {
            Console.Clear();
            Display(numberOfColumns, numberOfRings);
            bool Finish = false;
            for (int i = 0; i < numberOfColumns; i++)
            {
                Finish |= ColumnsOfGame[i].GetCount() == numberOfRings;
            }
            if (!Finish)
            {
                int Origin = 0;
                int Destination = 0;
                Console.WriteLine("\r\n  Move from Column:");
                try
                {
                    Console.Write("  ");
                    Origin = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Incorrect input");
                }
                Console.WriteLine("  to Column:");
                try
                {
                    Console.Write("  ");
                    Destination = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Incorrect input");
                }
                if (Origin <= numberOfColumns && Destination <= numberOfColumns)
                {
                    if (Origin != Destination)
                    {
                        if (!ColumnsOfGame[Origin - 1].IsEmpty())
                            ColumnsOfGame[Destination - 1].Push(ColumnsOfGame[Origin - 1].Pop());
                    }
                }
                RingMover(numberOfColumns, numberOfRings);
            }
            Display(numberOfColumns, numberOfRings);
            Console.WriteLine("\r\n    Finish");
            Console.WriteLine("    Press any key to exit");
            Console.ReadKey();
        }
        private static int FindItem(int numberOfColumns, int numberOfRings, int num)
        {
            for (int k = 0; k < numberOfRings; k++)
            {
                for (int i = 0; i < numberOfColumns; i++)
                {
                    if (ColumnsOfGame[i].GetItem(k) == num.ToString())
                        return i;
                }
            }
            return 0;
        }
    }
}
