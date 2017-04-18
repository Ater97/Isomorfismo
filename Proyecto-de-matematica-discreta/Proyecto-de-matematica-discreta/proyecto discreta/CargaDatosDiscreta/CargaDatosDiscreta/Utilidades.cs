using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaDatosDiscreta
{
    class Utilidades
    {
        public static Comparacion comparar = new Comparacion();
        
        /// <summary>
        /// Obtiene el string para poder comparar la funcion.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string ObtenerArreglo(int numero)
        {
            string arreglo = "";
            for(int i=0;i<numero;i++)
            {
                arreglo += i.ToString();
            }
            return arreglo;
        }

        /// <summary>
        /// Cambio, reordena los elementos de un arreglo.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Cambio(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// Permuta el grafo 2
        /// </summary>
        /// <param name="PrimerGrafo"> Vertices de la primera matriz</param>
        /// <param name="Permutacion"> Verices de la matriz permutada</param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[,] MatrizPermutada(string PrimerGrafo, string Permutacion, int n)
        {
            
            int[,] matriz = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = 0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                int pg1 = int.Parse(PrimerGrafo[i].ToString());
                int pg2 = int.Parse(Permutacion[i].ToString());
                matriz[pg1, pg2] = 1;
            }
            return matriz;
        }

        /// <summary>
        /// Genera la permutacion, la compara con el grafo original.
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <param name="cont"></param>
        /// <param name="Grafo1"></param>
        /// <param name="Grafo2"></param>
        public static void permute(char[] arry, int i, int n, ref int cont, Carga Grafo1, Carga Grafo2,ref bool bandera)
        {
            
            int j;
            
            if (i == n)
            {
                int[,] varMatrizPermutada = MatrizPermutada(ObtenerArreglo(Grafo2.cantVertices), converToString(arry), n);
                int[,] Ptraspuesto = comparar.Transpuesto(varMatrizPermutada, Grafo2.cantVertices);
                
                int[,] Permutacion_Semi_Final = comparar.Multiplicar( varMatrizPermutada, Grafo2.getVector(), Grafo2.cantVertices);

                int[,] PermutacionFinal = comparar.Multiplicar(Permutacion_Semi_Final, Ptraspuesto, Grafo2.cantVertices);

                
                

                if ( comparar.Compare_Permutacion(PermutacionFinal, Grafo1.getVector(), Grafo1.cantVertices))
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("No."+(cont+1));
                    Console.WriteLine("La funcion de Isomorfismo es:");
                    Console.WriteLine("Grafo 1: "+ObtenerArreglo(Grafo1.cantVertices));
                    Console.WriteLine("Grafo 2: "+converToString(arry));
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine(" ");
                    bandera = true;
                    cont++;
                    return;
                }
              
                 //Console.WriteLine(arry);
            }
            else
            {
                for (j = i; j < n; j++)
                {
                    Cambio(ref arry[i], ref arry[j]);
                    permute(arry, i + 1, n, ref cont, Grafo1, Grafo2,ref bandera);
                    Cambio(ref arry[i], ref arry[j]);
                }
            }
        }

        /// <summary>
        /// Funcion en la cual mandamos un char y lo convertimos en un string
        /// </summary>
        /// <param name="arry"></param>
        /// <returns></returns>
        public static string converToString(char[] arry)
        {
            string arryBueno = "";
            for (int i = 0; i < arry.Length; i++)
            {
                arryBueno += arry[i];
            }
            return arryBueno;
        }

        /// <summary>
        /// Imprimme una matriz tipo int[,]
        /// </summary>
        /// <param name="m1"></param>
        public static void printMatrix(int[,] m1)
        {
            Console.WriteLine();
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(0); j++)
                {
                    Console.Write(m1[i, j] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
