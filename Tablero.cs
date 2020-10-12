using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sudoku
{
    
    class Tablero
    {
        private string juego;
        private int[,] matrizOriginal;
        private int[,] matriz;

        private bool tableroIncompleto = true;
        public bool TableroIncompleto
        {
            get { 
                return tableroIncompleto; 
            }
        }

        public Tablero(string juego)
        {
            this.juego = juego;

            CrearMatriz();
        }

        public void CrearMatriz()
        {
            matrizOriginal = new int[9, 9];
            matriz = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matrizOriginal[i, j] = int.Parse("" + juego[j + i * 9]);
                    matriz[i,j] = matrizOriginal[i, j];
                }
            }


        }
        public void MostrarMatriz(int columna, int fila)
        {
            //Console.Clear();
            Console.SetCursorPosition(1, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - " + " S U D O K U     G A M E " + " - ");
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (fila == i && columna == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (IsCeldaValida(i,j))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(/*(fila==i&&columna==j ? "-" : " ")*/" " + (matriz[i, j] == 0 ? "-" : matriz[i, j].ToString()) + ((j + 1) % 3 == 0 ? " |" : " "));

                }
                Console.WriteLine();
                Console.WriteLine(((i + 1) % 3 == 0 ? "---------+---------+---------" : ""));
            }
        }

        public void SetCelda(int value, int fila, int columna)
        {
            //Habría que cambiar el try por varios if, para limitar lo que se ingresa,etc 
            try
            {
                if (matrizOriginal[fila, columna] == 0)
                {
                    matriz[fila, columna] = value;
                }
            }
            catch (Exception e)
            {

            }
        }

        private bool IsCeldaValida(int fila, int columna)
        {
            if (matriz[fila, columna] != 0)
            {
                //fila invalida (valor fila no se repite)
                for (int i = 0; i < 9; i++)
                {
                    if (
                        i != columna
                        &&
                        matriz[fila, i] ==
                        matriz[fila, columna])
                    {
                        return false;
                    }

                }
                //columna invailda (valor columna no se repite)
                for (int i = 0; i < 9; i++)
                {
                    if (
                        i != fila
                        &&
                        matriz[i,columna] ==
                        matriz[fila, columna])
                    {
                        return false;
                    }

                }

                //grupo invalido (valor dentro del 3x3 no se repite) 

            }
            return true;
        }
       

    }
}

