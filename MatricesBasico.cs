using System;
using System.Collections.Generic;

namespace pruebaDesarrolloOscar
{
	public class MatricesBasico
	{
		public MatricesBasico()
		{
		}

        public static void Main(string[] args)
        {
            Operaciones operador = new Operaciones();
            string file = "/Users/oarojasg/Projects/pruebaDesarrolloOscar/pruebaDesarrolloOscar/Matrices/map.txt";

            Console.WriteLine("Extrayendo Matriz...");
            var matrizInicial = operador.leerArchivo(file);

            //if (File.Exists("file.txt"))
            //{
            //    // Store each line in array of strings
            //    string[] lines = File.ReadAllLines(file);

            //    var matrizLeida = lines.Select(
            //        l => l.Split(" ").Select(int.Parse).ToList()).ToList();
            //    operador.mostrarMatrizEnConsola(matrizLeida, "Matriz leída:");
            //}

            //var matrizInicial = new List<List<int>>()
            //{
            //    new List<int> { 4, 8, 7, 3 },
            //    new List<int> { 2, 5, 9, 3 },
            //    new List<int> { 6, 3, 2, 5 },
            //    new List<int> { 4, 4, 1, 6 }
            //};
            Console.WriteLine("Matriz extraida exitosamente.");
            //operador.mostrarMatrizEnConsola(matrizInicial, "Matriz inicial:");

            //var subIzquierda = new List<List<int>>(matrizInicial.Select(f => f.SkipLast(1).ToList()));
            //foreach (var f in subIzquierda) f.Insert(0,0);
            //operador.mostrarMatrizEnConsola(subIzquierda, "Submatriz izquierda:");

            //var subDerecha = new List<List<int>>(matrizInicial.Select(f => f.Skip(1).ToList()));
            //operador.mostrarMatrizEnConsola(subDerecha, "Submatriz derecha:");

            var pesosDerecha = operador.operacionElemento(
                matrizInicial.Select(f => f.SkipLast(1).ToList()).ToList(),//subIzquierda,
                matrizInicial.Select(f => f.Skip(1).ToList()).ToList(),//subDerecha,
                operador.funcion(Operaciones.Operador.resta));
            //operador.mostrarMatrizEnConsola(pesosDerecha, "Pesos derecha:");

            //var subSuperior = new List<List<int>>(matrizInicial.SkipLast(1));
            //operador.mostrarMatrizEnConsola(subSuperior, "Submatriz superior:");

            //var subInferior = new List<List<int>>(matrizInicial.Skip(1));
            //operador.mostrarMatrizEnConsola(subInferior, "Submatriz inferior:");

            var pesosHaciaAbajo = operador.operacionElemento(
                matrizInicial.SkipLast(1).ToList(),//subSuperior,
                matrizInicial.Skip(1).ToList(),//subInferior,
                operador.funcion(Operaciones.Operador.resta));
            //operador.mostrarMatrizEnConsola(pesosHaciaAbajo, "Pesos hacia abajo:");

            //var maximosPorFila = new List<List<int>>();
            //foreach (var fila in matrizInicial)
            //{

            //    var indice = matrizInicial.IndexOf(fila);
            //    var filaTemporal = new List<int>(new int[fila.Count]);
            //    for (int j = 0; j < fila.Count; j++)
            //    {
            //        if (j == 0)
            //        {
            //            if (pesosDerecha[indice][j] >= 0) filaTemporal[j] = 1;
            //        }
            //        else if (j < fila.Count - 1)
            //        {
            //            if (
            //               pesosDerecha[indice][j] >= 0
            //            && pesosDerecha[indice][j - 1] <= 0) filaTemporal[j] = 1;
            //        }
            //        else
            //        {
            //            if (pesosDerecha[indice][j - 1] <= 0) filaTemporal[j] = 1;
            //        }
            //    }
            //    maximosPorFila.Add(filaTemporal);
            //}
            //operador.mostrarMatrizEnConsola(maximosPorFila, "Máximos por fila:");

            //var maximosPorColumna = new List<List<int>>();
            //foreach (var fila in matrizInicial) maximosPorColumna.Add(new List<int>());

            //for (int j = 0; j < matrizInicial[0].Count; j++)
            //{
            //    var columnaTemporal = new List<int>(new int[matrizInicial.Count]);
            //    foreach (var fila in matrizInicial)
            //    {
            //        var indice = matrizInicial.IndexOf(fila);
            //        if (indice == 0)
            //        {
            //            if (pesosHaciaAbajo[indice][j] >= 0) columnaTemporal[indice] = 1;
            //        }
            //        else if (indice < matrizInicial.Count - 1)
            //        {
            //            if (
            //               pesosHaciaAbajo[indice][j] >= 0
            //            && pesosHaciaAbajo[indice - 1][j] <= 0) columnaTemporal[indice] = 1;
            //        }
            //        else
            //        {
            //            if (pesosHaciaAbajo[indice - 1][j] <= 0) columnaTemporal[indice] = 1;
            //        }
            //    }
            //    for (int i = 0; i < columnaTemporal.Count; i++)
            //    {
            //        maximosPorColumna[i].Add(columnaTemporal[i]);
            //    }
            //}
            //operador.mostrarMatrizEnConsola(maximosPorColumna, "Máximos por columna:");
            Console.WriteLine("Obteniendo maximos...");
            var maximos = operador.encontrarMaximos(matrizInicial, pesosDerecha, pesosHaciaAbajo);
            //var maximos = operador.operacionElemento(
            //    maximosPorFila,
            //    maximosPorColumna,
            //    operador.funcion(Operaciones.Operador.andEntero)
            //    );
            //var maximos = new List<List<int>>(maximosPorFila.Zip(maximosPorColumna,
            //    (a, b) => a.Zip(b,
            //    (x, y) => Convert.ToInt32(x == 1 && y == 1)).ToList()
            //));


            //operador.mostrarMatrizEnConsola(maximos, "Máximos:");

            //var minimosPorFila = new List<List<int>>();
            //foreach (var fila in matrizInicial)
            //{

            //    var indice = matrizInicial.IndexOf(fila);
            //    var filaTemporal = new List<int>(new int[fila.Count]);
            //    for (int j = 0; j < fila.Count; j++)
            //    {
            //        if (j == 0)
            //        {
            //            if (pesosDerecha[indice][j] <= 0) filaTemporal[j] = 1;
            //        }
            //        else if (j < fila.Count - 1)
            //        {
            //            if (
            //               pesosDerecha[indice][j] <= 0
            //            && pesosDerecha[indice][j - 1] >= 0) filaTemporal[j] = 1;
            //        }
            //        else
            //        {
            //            if (pesosDerecha[indice][j - 1] >= 0) filaTemporal[j] = 1;
            //        }
            //    }
            //    minimosPorFila.Add(filaTemporal);
            //}
            ////operador.mostrarMatrizEnConsola(maximosPorFila, "Máximos por fila:");

            //var minimosPorColumna = new List<List<int>>();
            //foreach (var fila in matrizInicial) minimosPorColumna.Add(new List<int>());

            //for (int j = 0; j < matrizInicial[0].Count; j++)
            //{
            //    var columnaTemporal = new List<int>(new int[matrizInicial.Count]);
            //    foreach (var fila in matrizInicial)
            //    {
            //        var indice = matrizInicial.IndexOf(fila);
            //        if (indice == 0)
            //        {
            //            if (pesosHaciaAbajo[indice][j] <= 0) columnaTemporal[indice] = 1;
            //        }
            //        else if (indice < matrizInicial.Count - 1)
            //        {
            //            if (
            //               pesosHaciaAbajo[indice][j] <= 0
            //            && pesosHaciaAbajo[indice - 1][j] >= 0) columnaTemporal[indice] = 1;
            //        }
            //        else
            //        {
            //            if (pesosHaciaAbajo[indice - 1][j] >= 0) columnaTemporal[indice] = 1;
            //        }
            //    }
            //    for (int i = 0; i < columnaTemporal.Count; i++)
            //    {
            //        minimosPorColumna[i].Add(columnaTemporal[i]);
            //    }
            //}
            //operador.mostrarMatrizEnConsola(maximosPorColumna, "Máximos por columna:");
            Console.WriteLine("Obteniendo minimos...");
            var minimos = operador.encontrarMinimos(matrizInicial, pesosDerecha, pesosHaciaAbajo);
            //var minimos = operador.operacionElemento(
            //    minimosPorFila,
            //    minimosPorColumna,
            //    operador.funcion(Operaciones.Operador.andEntero)
            //    );

            //var minimos = new List<List<int>>(minimosPorFila.Zip(minimosPorColumna,
            //    (a, b) => a.Zip(b,
            //    (x, y) => Convert.ToInt32(x == 1 && y == 1)).ToList()
            //));

            //operador.mostrarMatrizEnConsola(minimos, "Mínimos:");

            //var nodosMatriz = new List<Nodo>();
            //for (int i = 0; i < maximos.Count; i++)
            //{
            //    for (int j = 0; j < maximos[i].Count; j++)
            //    {
            //        if (maximos[i][j] == 1)
            //        {
            //            nodosMatriz.Add(new Nodo(i, j, 0));

            //        }
            //    }
            //}

            //do
            //{
            //    var nodoExaminar = nodosMatriz
            //        .Where(n => n.invalido == false)
            //        .Where(n => n.marcado == false)
            //        .FirstOrDefault();

            //    //foreach (var nodoExaminar in nodosMatriz)
            //    //Console.WriteLine(
            //    //"{ " + nodoExaminar.fila + " " + nodoExaminar.columna + " " + nodoExaminar.distancia + " " +
            //    //nodoExaminar.indiceNodoAnterior + " " + nodoExaminar.marcado + " [" + String.Join(" ", nodoExaminar.ruta)
            //    //+ "] " + nodoExaminar.invalido + " }");
            //    //Console.WriteLine();

            //    if (nodoExaminar != null)
            //    {
            //        if (minimos[nodoExaminar.fila][nodoExaminar.columna] == 0)
            //        {
            //            if (nodoExaminar.fila == 2 && nodoExaminar.columna == 1)
            //            {
            //                Console.WriteLine(nodoExaminar);
            //            }

            //            var nodosEncontrados = encontrarNodosProximos(
            //            matrizInicial, nodoExaminar.fila, nodoExaminar.columna);

            //            //foreach (var nodo in nodosEncontrados) Console.WriteLine(nodo.fila+" "+nodo.columna+" "+nodo.distancia);


            //            foreach (var nodo in nodosEncontrados)
            //            {
            //                if (nodoExaminar.ruta.Count > 0) nodo.ruta.AddRange(nodoExaminar.ruta);
            //                nodo.ruta.Add(matrizInicial[nodoExaminar.fila][nodoExaminar.columna]);

            //                if (nodosMatriz.Where(
            //                    x => x.fila == nodo.fila && x.columna == nodo.columna)
            //                    .ToList().Count > 0)
            //                {
            //                    var nodoAntiguo = nodosMatriz.Where(
            //                        x => x.fila == nodo.fila && x.columna == nodo.columna)
            //                        .FirstOrDefault();
            //                    if (nodoAntiguo != null)
            //                    {
            //                        if (nodoAntiguo.ruta[0] > nodo.ruta[0]
            //                            || (nodoAntiguo.ruta[0] == nodo.ruta[0]
            //                                && nodoAntiguo.ruta.Count > nodo.ruta.Count
            //                            )
            //                            )
            //                        {
            //                            nodo.invalido = true;
            //                        }
            //                        else
            //                        {
            //                            //nodo.ruta = nodoAntiguo.ruta;
            //                            //nodo.indiceNodoAnterior = nodoAntiguo.indiceNodoAnterior;
            //                            //nodo.marcado = nodoAntiguo.marcado;
            //                            nodosMatriz[nodosMatriz.IndexOf(nodoAntiguo)].invalido = true;
            //                        }
            //                    }
            //                }
            //            }

            //            nodosEncontrados = nodosEncontrados.Where(n => n.invalido == false).ToList();

            //            if (nodosEncontrados.Count > 0)
            //            {
            //                if (nodosEncontrados.Where(n => n.invalido == false).ToList().Count > 1)
            //                {
            //                    var pesos = nodosEncontrados
            //                        //.Where(n => n.invalido == false)
            //                        //.Where(t => t.marcado == false)
            //                        .Select(x => x.distancia);
            //                    var minimo = pesos.Min();
            //                    var nodoEscogido = nodosEncontrados
            //                        //.Where(n => n.invalido == false)
            //                        .Where(s => s.distancia == minimo)
            //                        .FirstOrDefault();
            //                    if (nodoEscogido != null)
            //                    {
            //                        nodosEncontrados.Remove(nodoEscogido);
            //                        nodoEscogido.indiceNodoAnterior = nodosMatriz.IndexOf(nodoExaminar);
            //                        //if (nodoExaminar.ruta.Count > 0) nodoEscogido.ruta.AddRange(nodoExaminar.ruta);
            //                        //nodoEscogido.ruta.Add(
            //                        //    matrizInicial[nodoExaminar.fila][nodoExaminar.columna]);
            //                        //nodoEscogido.marcado = true;
            //                        nodosMatriz.Add(nodoEscogido);
            //                    }
            //                    nodosMatriz.AddRange(nodosEncontrados);
            //                }
            //                else
            //                {
            //                    nodosEncontrados[0].indiceNodoAnterior = nodosMatriz.IndexOf(nodoExaminar);
            //                    //if (nodoExaminar.ruta.Count > 0) nodosEncontrados[0].ruta.AddRange(nodoExaminar.ruta);
            //                    //nodosEncontrados[0].ruta.Add(
            //                    //    matrizInicial[nodoExaminar.fila][nodoExaminar.columna]);
            //                    //nodosEncontrados[0].marcado = true;
            //                    nodosMatriz.Add(nodosEncontrados[0]);
            //                }
            //            }
            //        }
            //        nodosMatriz[nodosMatriz.IndexOf(nodoExaminar)].marcado = true;
            //    }

            //}
            //while (nodosMatriz.Exists(n => n.marcado == false && n.invalido == false));

            Console.WriteLine("Calculando rutas...");
            var nodosMatriz2 = operador.crearRutas(matrizInicial, maximos, minimos);
            Console.WriteLine("Rutas calculadas exitosamente.");
            //foreach (var nodo in nodosMatriz2) Console.WriteLine(
            //    "{ " + nodo.fila + " " + nodo.columna + " " + nodo.distancia + " " +
            //    nodo.indiceNodoAnterior + " " + nodo.marcado + " [" + String.Join(" ",nodo.ruta)
            //    + "] " + nodo.invalido + " }");

            var nodoEscogido = nodosMatriz2.OrderByDescending(n => n.ruta.Count).First();
            var ultimoNodo = matrizInicial[nodoEscogido.fila][nodoEscogido.columna];
            var rutaEscogida = nodoEscogido.ruta;
            rutaEscogida.Add(ultimoNodo);
            Console.WriteLine("Name: " + "Oscar Rojas");
            Console.WriteLine("Length of calculated path: " + (rutaEscogida.Count));
            Console.WriteLine("Drop of calculated path: "
                + (rutaEscogida[0] - rutaEscogida[rutaEscogida.Count -1]));
            Console.WriteLine("Calculated path: " + String.Join("-",rutaEscogida));

        }
	}
}

