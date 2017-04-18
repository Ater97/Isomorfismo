using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaDatosDiscreta
{
    class Carga
    {
        public Aristas[,] aristasC;
        public int cantVertices = 0;
        public int cantAristas = 0;
        string[] verticesAdyacentes;
        public int[] grados;
        bool aislado = false;
        bool circuitoEuleriano = false;
        bool recorridoEuleriano = false;
        int[,] vector;

        /// <summary>
        ///  Carga los datos a las matrices y los ejecuta.
        /// </summary>
        /// <param name="strRutaArchivo"></param>
        /// <returns></returns>
        public bool CargaryEjecutarDatosArchivo(string strRutaArchivo)
        {
            bool bolResultadoOperacion = true;
                //Variable que guardará el resultado de las operaciones que realizará el método
            StreamReader objArchivo = null; //objeto que manejará el archivo
            string[] arrDatos = null; //arreglo de datos por línea
            string strLinea = "";
            int verticeX = 0;
            int verticeY = 0;
            int aristaMayor = 0;

            try
            {
                //Comprobar que el archivo exista
                if (File.Exists(strRutaArchivo))
                {
                    objArchivo = new StreamReader(strRutaArchivo);
                        //Si existe el archivo, crear un objeto que lo gestione
                    strLinea = objArchivo.ReadLine(); //Lectura de la primera linea.

                    //Guarda la cantidad de vertices y crea la matriz n*n
                    try
                    {
                        arrDatos = strLinea.Split();
                        cantVertices = Convert.ToInt32(arrDatos[0].Trim());
                        Console.WriteLine("" + cantVertices);
                        aristasC = new Aristas[cantVertices, cantVertices];
                        LlenarMatriz();
                    }
                    catch
                    {

                    }

                    strLinea = objArchivo.ReadLine(); //Lectura de la segunda linea.
                    while (strLinea != null) //Si la línea no está vacía
                    {
                        try
                        {
                            //Dividir datos en una línea por coma.
                            arrDatos = strLinea.Split(',');

                            verticeX = Convert.ToInt32(arrDatos[0].Trim());
                            verticeY = Convert.ToInt32(arrDatos[1].Trim());
                            if (aristaMayor < verticeX)
                            {
                                aristaMayor = verticeX;
                            }
                            if (aristaMayor < verticeY)
                            {
                                aristaMayor = verticeY;
                            }
                            Console.WriteLine("" + verticeX + ", " + verticeY);
                            aristasC[verticeX, verticeY].arista = true;
                            aristasC[verticeY, verticeX].arista = true;
                            cantAristas++;
                        }
                        catch (Exception e)
                        {

                        }
                        strLinea = objArchivo.ReadLine(); //Leer siguiente línea de archivo
                    }
                    if (aristaMayor >= cantVertices)
                    {
                        bolResultadoOperacion = false;
                    }
                }
            }
            catch (Exception e)
            {
                bolResultadoOperacion = false; //Señalar que la operación no fue exitosa
            }
            finally
            {
                try
                {
                    objArchivo.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Archivo Erroneo");
                    Console.ReadLine();
                    bolResultadoOperacion = false;
                }
            }
            //Devolver el resultado de la carga de datos
            return bolResultadoOperacion;
        }

        /// <summary>
        /// Genera una matriz de aadyacencia tipo bool respecto al grafo ingresado
        /// </summary>
        private void LlenarMatriz()
        {
            for (int filas = 0; filas < aristasC.GetLength(0); filas++)
            {
                for (int columnas = 0; columnas < aristasC.GetLength(1); columnas++)
                {
                    Aristas arista = new Aristas();
                    aristasC[filas, columnas] = arista;
                }
            }
        }

        /// <summary>
        /// Calcula el grado de cada veritce
        /// </summary>
        /// <param name="aristas"> matriz de adyacencia</param>
        /// <param name="vertices">No. de vertices</param>
        /// <returns></returns>
        public int[] calcGrado(Aristas[,] aristas, int vertices)
        {
            
            grados = new int[cantVertices];
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (aristas[i, j].arista)
                    {
                        grados[i]++;
                    }
                }
            }
            return grados;
        }
 
        /// <summary>
        /// Calcula los vertices aislados.
        /// </summary>
        /// <returns></returns>
        public bool calcAislados()
        {
            for (int i = 0; i < grados.Length; i++)
            {
                if (grados[i] == 0)
                    aislado = true;
            }
            return aislado;
        }

        /// <summary>
        /// Calcula si el grafo posee un circuito euleriano.
        /// </summary>
        /// <returns></returns>
        public bool calcCirEul()
        {
            int sum = 0;
            for (int i = 0; i < grados.Length; i++)
            {
                sum += grados[i];
            }
            if (sum % 2 == 0 && !aislado)
                circuitoEuleriano = true;
            
            return circuitoEuleriano;
        }

        /// <summary>
        /// Calcular sie le grafo posee un recorido euleriano
        /// </summary>
        /// <returns></returns>
        public bool calRerEul()
        {
            int sumImpar = 0;
            int sumPar = 0;
            for (int i = 0; i < grados.Length; i++)
            {
                if (grados[i] % 2 == 0)
                    sumPar++;
                else
                    sumImpar++;
            }
            if (sumImpar == 2 && !aislado)
                recorridoEuleriano = true;
            return recorridoEuleriano;
        }

        /// <summary>
        /// Inicializa el vector con 0
        /// </summary>
        /// <param name="n"></param>
        public void inicializar(int n)
        {
            vector = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    vector[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Convierte la matriz de booleanos a una matriz de int
        /// </summary>
        /// <returns></returns>
        public int[,] getVector()
        {
            inicializar(cantVertices);
            for (int i = 0; i < cantVertices; i++)
            {
                for (int j = 0; j < cantVertices; j++)
                {
                    if (aristasC[i, j].arista)
                        vector[i, j] = 1;
                }
            }
            return vector;
        }
    }
}
