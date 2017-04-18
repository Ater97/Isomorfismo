
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaDatosDiscreta
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            bool seguir = true;
            do
            {
                Comparacion comparacion = new Comparacion();
                Carga Grafo1 = new Carga();
                Carga Grafo2 = new Carga();
                Utilidades varios = new Utilidades();
                bool bandera = false;
                bool carga1 = true;
                bool carga2 = true;

                while (carga1)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese direccion del archivo:");
                    string address = Console.ReadLine();
                    if (address.Contains(".txt"))
                    {
                        if (Grafo1.CargaryEjecutarDatosArchivo(address))
                        {
                            Console.ReadLine();
                            carga1 = false;
                        }
                        else
                        {
                            Console.WriteLine("Formato de archivo invalido.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Archivo invalido; vuelva a inte" +
                                          "ntarlo\nPresione Enter para continuar");
                        Console.ReadLine();
                    }

                }

                while (carga2)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese direccion del segundo archivo:");
                    string address2 = Console.ReadLine();
                    if (address2.Contains(".txt"))
                    {
                        if (Grafo2.CargaryEjecutarDatosArchivo(address2))
                        {
                            Console.ReadLine();
                            carga2 = false;
                        }
                        else
                        {
                            Console.WriteLine("Formato de archivo invalido.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Archivo invalido; vuelva a " +
                                          "intentarlo\nPresione Enter para continuar");
                        Console.ReadLine();

                    }
                }
                Console.Clear();

                Grafo1.calcGrado(Grafo1.aristasC, Grafo1.cantVertices);

                Grafo2.calcGrado(Grafo2.aristasC, Grafo2.cantVertices);

                Grafo1.calcAislados();
                Grafo2.calcAislados();

                Console.WriteLine("");

                if (Grafo1.cantVertices != Grafo2.cantVertices)
                {
                    Console.WriteLine();
                    Console.WriteLine("Los grafos no son isomorfos. No poseen la misma cantidad de vertices.");
                    Console.WriteLine("Cantidad vertices grafos 1 es: " + Grafo1.cantVertices);
                    Console.WriteLine("Cantidad vertices grafos 2 es: " + Grafo2.cantVertices);
                    Console.WriteLine();
                }
                else if (Grafo1.cantAristas != Grafo2.cantAristas)
                {
                    Console.WriteLine();
                    Console.WriteLine("Los grafos no son isomorfos. No poseen la misma cantidad de aristas.");
                    Console.WriteLine("Cantidad aristas grafos 1 es: " + Grafo1.cantAristas);
                    Console.WriteLine("Cantidad aristas grafos 2 es: " + Grafo2.cantAristas);
                    Console.WriteLine();
                }
                else if (Grafo1.calcCirEul() != Grafo2.calcCirEul())
                {
                    Console.WriteLine("Los grafos no son isomorfos, debido a que uno de los dos tiene circuito euleriano");
                }

                else if (Grafo1.calRerEul() != Grafo2.calRerEul())
                {
                    Console.WriteLine("Los grafos no son isomorfos, debido a que uno de los dos tiene recorrido euleriano");
                }

                else if (!comparacion.calcGraIgu(Grafo1.calcGrado(Grafo1.aristasC, Grafo1.cantVertices), Grafo1.calcGrado(Grafo1.aristasC, Grafo1.cantVertices)))
                {
                    Console.WriteLine("Los grafos no son isomorfos, debido a que los grados de los vertices no son iguales");
                }
                else
                {
                    int cont = 0;

                    Utilidades.permute(Utilidades.ObtenerArreglo(Grafo2.cantVertices).ToArray(), 0, Utilidades.ObtenerArreglo(Grafo2.cantVertices).ToArray().Length, ref cont, Grafo1, Grafo2, ref bandera);
                    
                    if (!bandera)
                    {
                        Console.WriteLine("Los grafos no son isomorfos, debido a que no se encontro funcion");
                    }
                    Console.WriteLine("Terminado");
                }
                Console.ReadLine();
                Console.Clear();
                bool continuar = true;
                do
                {
                    Console.WriteLine("Desea comprobar otros grafos S/N  ?");
                    string respuesta = Console.ReadLine().ToLower();
                    switch (respuesta)
                    {
                        case "s":
                            continuar = false;
                            break;
                        case "n":
                            Console.Clear();
                            Console.WriteLine("Todos los derechos reservados (C). 2016\nHarry Caballeros\nDavid Munguia" +
                                              "\nSebastian Orantes\nSebastian Bonilla");
                            continuar = false;
                            seguir = false;
                            break;
                        default:
                            Console.WriteLine("Ingreso una opcion invalida\n Presione " +
                                              "ENTER para continuar");
                            Console.ReadLine();
                            break;
                    }

                } while (continuar);
                
                


                Console.ReadLine();

            } while(seguir);
            // Instancia los objetos Comparacion, grafo1, grafo2 y varios 
           
        }

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
