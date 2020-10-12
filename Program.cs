using System;
using System.Collections.Generic;


namespace Sudoku
{
    class Program
    {
        static int fila = 0, columna = 0;

        static void Main(string[] args)
        {          

            var rnd = new Random();
            int index = rnd.Next(Juegos.juegos.Count);

            Tablero tablero = new Tablero(Juegos.juegos[index]);

            tablero.MostrarMatriz(columna, fila);

            while (tablero.TableroIncompleto)
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
                if (int.TryParse("" + key.KeyChar, out value))
                {
                    tablero.SetCelda(value, fila, columna);
                    
                }

                tablero.MostrarMatriz( columna, fila);
            }

        }

    }
}
