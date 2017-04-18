using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaDatosDiscreta
{
    class Comparacion
    {
        bool gradosIguales = false;


        public bool calcGraIgu(int[] grados1, int[] grados2)
        {
            Array.Sort(grados1);
            Array.Sort(grados2);
            gradosIguales = Enumerable.SequenceEqual(grados1, grados2);
            return gradosIguales;
        }

        public int[,]Multiplicar(int[,]matrix1, int[,]matrix2, int lenght)
        {
            int lenght1 = matrix1.GetLength(0);
            int[,] resultado = new int[lenght1, lenght1];
            for (int row = 0; row < lenght1; row++)
            {
                for (int col = 0; col < lenght1; col++)
                {
                    resultado[row, col] = 0;
                    for (int i = 0; i < lenght1; i++)
                    {
                        resultado[row, col] = resultado[row, col] + matrix1[row, i] * matrix2[i, col];
                    }
                }
            }
            return resultado;
        }

        public int[,]Transpuesto(int[,]matrix1,int lenght)
        {
           int[,] vector = new int[lenght, lenght];
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    vector[j, i] = matrix1[i, j];
                }
            }
            return vector;
        }
        public bool Compare_Permutacion(int[,] vector1, int[,] vector2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (vector1[i, j] != vector2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public int Factorial(int numero)
        {
            if (numero == 1)
                return numero;
            else
            return numero*Factorial(numero-1);
        }
    }
}
