using System;
using System.Collections.Generic;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] matriz = new int[9,9];

            int fila = 0, columna = 0;

            CrearMatriz(matriz);
            MostrarMatriz(matriz,columna,fila);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        columna++;
                        break;
                    case ConsoleKey.LeftArrow:
                        columna--;
                        break;
                    case ConsoleKey.DownArrow:
                        fila++;
                        break;
                    case ConsoleKey.UpArrow:
                        fila--;
                        break;
                }

                int value;
                if (int.TryParse(""+key.KeyChar,out value))
                {
                    try
                    {
                        matriz[fila, columna] = value;
                    }
                    catch (Exception e)
                    {

                    }
                }

                MostrarMatriz(matriz, columna, fila);
            }

        }


        private static List<string> juegos = new List<string>(){
            "023500089008910350049000060000089675095020800386700000900060024007000916204097030",
            "015004000002700006006002941024008000700421005500309070008900513497030008103086794",
            "901005002000900006430608519509076430308500020000380975150060000780104000000800167" };


        private static void CrearMatriz(int[,] matriz)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matriz[i , j ] = int.Parse(""+juegos[0][j+i*9]);
                }
            }
            
        }
        private static void MostrarMatriz(int[,] matriz,int columna, int fila)
        {
            //Console.Clear();
            Console.SetCursorPosition(1,0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - "+" S U D O K U     G A M E "+ " - ");
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (fila == i && columna == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; 
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(/*(fila==i&&columna==j ? "-" : " ")*/" " + (matriz[i, j]==0?"-":matriz[i,j].ToString())+((j+1)%3==0?" |":" "));

                }
                Console.WriteLine();
                Console.WriteLine(((i + 1) % 3 == 0 ? "---------+---------+---------" : ""));
            }
        }
    }
}
