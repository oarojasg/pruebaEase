using System;
using static pruebaDesarrolloOscar.Operaciones;

namespace pruebaDesarrolloOscar
{
	public class Operaciones
	{
		public enum Operador
		{
			resta,
			andEntero
		}

		public Func<int,int,int> funcion(Operador op)
		{
			switch (op)
			{
				case Operador.resta:
					return (x, y) => x - y;
				case Operador.andEntero:
					return (x, y) => Convert.ToInt32(x == 1 && y == 1);
				default:
					return (x,y) => x - y;
            }
		}

        public void mostrarMatrizEnConsola(List<List<int>> matriz, string mensaje)
        {
            if (mensaje != "") Console.WriteLine(mensaje);
            Console.WriteLine(String.Join("\n", matriz.Select(f => String.Join(" ", f))));
            //foreach (var fila in matriz) Console.WriteLine(String.Join(" ", fila));
            Console.WriteLine();
        }

        public List<List<int>> operacionElemento(
            List<List<int>> primera
            , List<List<int>> segunda
            , Func<int, int, int> operacionFuncion
            )
        {
            if (primera.Count == segunda.Count && primera[0].Count == segunda[0].Count)
            {
                var resultado = new List<List<int>>(primera.Zip(segunda,
                    (a, b) => a.Zip(b,
                    operacionFuncion).ToList()));

                return resultado;
            }
            else throw new Exception("Dimensiones de las matrices no coinciden.");
        }

        public List<List<int>> encontrarMaximos(
            List<List<int>> matrizInicial,
            List<List<int>> pesosDerecha,
            List<List<int>> pesosHaciaAbajo
        )
        {
            if (matrizInicial.All(n => n.Count == matrizInicial[0].Count))
            {
                var maximosPorFila = new List<List<int>>();
                foreach (var fila in matrizInicial)
                {

                    var indice = matrizInicial.IndexOf(fila);
                    var filaTemporal = new List<int>(new int[fila.Count]);
                    for (int j = 0; j < fila.Count; j++)
                    {
                        if (j == 0)
                        {
                            if (pesosDerecha[indice][j] >= 0) filaTemporal[j] = 1;
                        }
                        else if (j < fila.Count - 1)
                        {
                            if (
                               pesosDerecha[indice][j] >= 0
                            && pesosDerecha[indice][j - 1] <= 0) filaTemporal[j] = 1;
                        }
                        else
                        {
                            if (pesosDerecha[indice][j - 1] <= 0) filaTemporal[j] = 1;
                        }
                    }
                    maximosPorFila.Add(filaTemporal);
                }
                //operador.mostrarMatrizEnConsola(maximosPorFila, "Máximos por fila:");

                var maximosPorColumna = new List<List<int>>();
                foreach (var fila in matrizInicial) maximosPorColumna.Add(new List<int>());

                for (int j = 0; j < matrizInicial[0].Count; j++)
                {
                    var columnaTemporal = new List<int>(new int[matrizInicial.Count]);
                    foreach (var fila in matrizInicial)
                    {
                        var indice = matrizInicial.IndexOf(fila);
                        if (indice == 0)
                        {
                            if (pesosHaciaAbajo[indice][j] >= 0) columnaTemporal[indice] = 1;
                        }
                        else if (indice < matrizInicial.Count - 1)
                        {
                            if (
                               pesosHaciaAbajo[indice][j] >= 0
                            && pesosHaciaAbajo[indice - 1][j] <= 0) columnaTemporal[indice] = 1;
                        }
                        else
                        {
                            if (pesosHaciaAbajo[indice - 1][j] <= 0) columnaTemporal[indice] = 1;
                        }
                    }
                    for (int i = 0; i < columnaTemporal.Count; i++)
                    {
                        maximosPorColumna[i].Add(columnaTemporal[i]);
                    }
                }
                var maximos = operacionElemento(
                    maximosPorFila,
                    maximosPorColumna,
                    funcion(Operaciones.Operador.andEntero)
                    );
                return maximos;
            }
            else throw new Exception("No todas las filas tienen la misma cantidad de elementos.");
        }

        public List<List<int>> encontrarMinimos(
            List<List<int>> matrizInicial,
            List<List<int>> pesosDerecha,
            List<List<int>> pesosHaciaAbajo
        )
        {
            if (matrizInicial.All(n => n.Count == matrizInicial[0].Count))
            {
                var minimosPorFila = new List<List<int>>();
                foreach (var fila in matrizInicial)
                {

                    var indice = matrizInicial.IndexOf(fila);
                    var filaTemporal = new List<int>(new int[fila.Count]);
                    for (int j = 0; j < fila.Count; j++)
                    {
                        if (j == 0)
                        {
                            if (pesosDerecha[indice][j] <= 0) filaTemporal[j] = 1;
                        }
                        else if (j < fila.Count - 1)
                        {
                            if (
                               pesosDerecha[indice][j] <= 0
                            && pesosDerecha[indice][j - 1] >= 0) filaTemporal[j] = 1;
                        }
                        else
                        {
                            if (pesosDerecha[indice][j - 1] >= 0) filaTemporal[j] = 1;
                        }
                    }
                    minimosPorFila.Add(filaTemporal);
                }
                //operador.mostrarMatrizEnConsola(maximosPorFila, "Máximos por fila:");

                var minimosPorColumna = new List<List<int>>();
                foreach (var fila in matrizInicial) minimosPorColumna.Add(new List<int>());

                for (int j = 0; j < matrizInicial[0].Count; j++)
                {
                    var columnaTemporal = new List<int>(new int[matrizInicial.Count]);
                    foreach (var fila in matrizInicial)
                    {
                        var indice = matrizInicial.IndexOf(fila);
                        if (indice == 0)
                        {
                            if (pesosHaciaAbajo[indice][j] <= 0) columnaTemporal[indice] = 1;
                        }
                        else if (indice < matrizInicial.Count - 1)
                        {
                            if (
                               pesosHaciaAbajo[indice][j] <= 0
                            && pesosHaciaAbajo[indice - 1][j] >= 0) columnaTemporal[indice] = 1;
                        }
                        else
                        {
                            if (pesosHaciaAbajo[indice - 1][j] >= 0) columnaTemporal[indice] = 1;
                        }
                    }
                    for (int i = 0; i < columnaTemporal.Count; i++)
                    {
                        minimosPorColumna[i].Add(columnaTemporal[i]);
                    }
                }

                var minimos = operacionElemento(
                    minimosPorFila,
                    minimosPorColumna,
                    funcion(Operaciones.Operador.andEntero)
                    );
                return minimos;
            }
            else throw new Exception("No todas las filas tienen la misma cantidad de elementos.");
        }

        public List<Nodo> crearRutas(
            List<List<int>> matrizInicial,
            List<List<int>> maximos,
            List<List<int>> minimos
            )
        {
            var nodosMatriz = new List<Nodo>();
            for (int i = 0; i < maximos.Count; i++)
            {
                for (int j = 0; j < maximos[i].Count; j++)
                {
                    if (maximos[i][j] == 1)
                    {
                        nodosMatriz.Add(new Nodo(i, j, 0));

                    }
                }
            }

            do
            {
                var nodoExaminar = nodosMatriz
                    .Where(n => n.invalido == false)
                    .Where(n => n.marcado == false)
                    .FirstOrDefault();

                //foreach (var nodoExaminar in nodosMatriz)
                //Console.WriteLine(
                //"{ " + nodoExaminar.fila + " " + nodoExaminar.columna + " " + nodoExaminar.distancia + " " +
                //nodoExaminar.indiceNodoAnterior + " " + nodoExaminar.marcado + " [" + String.Join(" ", nodoExaminar.ruta)
                //+ "] " + nodoExaminar.invalido + " }");
                //Console.WriteLine();

                if (nodoExaminar != null)
                {
                    if (minimos[nodoExaminar.fila][nodoExaminar.columna] == 0)
                    {
                        //if (nodoExaminar.fila == 2 && nodoExaminar.columna == 1)
                        //{
                        //    Console.WriteLine(nodoExaminar);
                        //}

                        var nodosEncontrados = encontrarNodosProximos(
                        matrizInicial, nodoExaminar.fila, nodoExaminar.columna);

                        //foreach (var nodo in nodosEncontrados) Console.WriteLine(nodo.fila+" "+nodo.columna+" "+nodo.distancia);


                        foreach (var nodo in nodosEncontrados)
                        {
                            if (nodoExaminar.ruta.Count > 0) nodo.ruta.AddRange(nodoExaminar.ruta);
                            nodo.ruta.Add(matrizInicial[nodoExaminar.fila][nodoExaminar.columna]);

                            if (nodosMatriz.Where(
                                x => x.fila == nodo.fila && x.columna == nodo.columna)
                                .ToList().Count > 0)
                            {
                                var nodoAntiguo = nodosMatriz.Where(
                                    x => x.fila == nodo.fila && x.columna == nodo.columna)
                                    .FirstOrDefault();
                                if (nodoAntiguo != null)
                                {
                                    if (nodoAntiguo.ruta[0] > nodo.ruta[0]
                                        || (nodoAntiguo.ruta[0] == nodo.ruta[0]
                                            && nodoAntiguo.ruta.Count > nodo.ruta.Count
                                        )
                                        )
                                    {
                                        nodo.invalido = true;
                                    }
                                    else
                                    {
                                        //nodo.ruta = nodoAntiguo.ruta;
                                        //nodo.indiceNodoAnterior = nodoAntiguo.indiceNodoAnterior;
                                        //nodo.marcado = nodoAntiguo.marcado;
                                        nodosMatriz[nodosMatriz.IndexOf(nodoAntiguo)].invalido = true;
                                    }
                                }
                            }
                        }

                        nodosEncontrados = nodosEncontrados.Where(n => n.invalido == false).ToList();

                        if (nodosEncontrados.Count > 0)
                        {
                            if (nodosEncontrados.Where(n => n.invalido == false).ToList().Count > 1)
                            {
                                var pesos = nodosEncontrados
                                    //.Where(n => n.invalido == false)
                                    //.Where(t => t.marcado == false)
                                    .Select(x => x.distancia);
                                var minimo = pesos.Min();
                                var nodoEscogido = nodosEncontrados
                                    //.Where(n => n.invalido == false)
                                    .Where(s => s.distancia == minimo)
                                    .FirstOrDefault();
                                if (nodoEscogido != null)
                                {
                                    nodosEncontrados.Remove(nodoEscogido);
                                    nodoEscogido.indiceNodoAnterior = nodosMatriz.IndexOf(nodoExaminar);
                                    //if (nodoExaminar.ruta.Count > 0) nodoEscogido.ruta.AddRange(nodoExaminar.ruta);
                                    //nodoEscogido.ruta.Add(
                                    //    matrizInicial[nodoExaminar.fila][nodoExaminar.columna]);
                                    //nodoEscogido.marcado = true;
                                    nodosMatriz.Add(nodoEscogido);
                                }
                                nodosMatriz.AddRange(nodosEncontrados);
                            }
                            else
                            {
                                nodosEncontrados[0].indiceNodoAnterior = nodosMatriz.IndexOf(nodoExaminar);
                                //if (nodoExaminar.ruta.Count > 0) nodosEncontrados[0].ruta.AddRange(nodoExaminar.ruta);
                                //nodosEncontrados[0].ruta.Add(
                                //    matrizInicial[nodoExaminar.fila][nodoExaminar.columna]);
                                //nodosEncontrados[0].marcado = true;
                                nodosMatriz.Add(nodosEncontrados[0]);
                            }
                        }
                    }
                    nodosMatriz[nodosMatriz.IndexOf(nodoExaminar)].marcado = true;
                }

            }
            while (nodosMatriz.Exists(n => n.marcado == false && n.invalido == false));

            return nodosMatriz;
        }

        public List<Nodo> encontrarNodosProximos(List<List<int>> matrizInicial, int i, int j)
        {
            var nodosEncontrados = new List<Nodo>();
            if (i > 0 && i < matrizInicial.Count - 1)
            {
                if (matrizInicial[i - 1][j] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i - 1,
                        j,
                        matrizInicial[i][j] - matrizInicial[i - 1][j]));
                if (matrizInicial[i + 1][j] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i + 1,
                        j,
                        matrizInicial[i][j] - matrizInicial[i + 1][j]));
            }
            else if (i > 0)
            {
                if (matrizInicial[i - 1][j] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i - 1,
                        j,
                        matrizInicial[i][j] - matrizInicial[i - 1][j]));
            }
            else
            {
                if (matrizInicial[i + 1][j] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i + 1,
                        j,
                        matrizInicial[i][j] - matrizInicial[i + 1][j]));
            }

            if (j > 0 && j < matrizInicial[0].Count - 1)
            {
                if (matrizInicial[i][j - 1] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i,
                        j - 1,
                        matrizInicial[i][j] - matrizInicial[i][j - 1]));
                if (matrizInicial[i][j + 1] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i,
                        j + 1,
                        matrizInicial[i][j] - matrizInicial[i][j + 1]));
            }
            else if (j > 0)
            {
                if (matrizInicial[i][j - 1] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i,
                        j - 1,
                        matrizInicial[i][j] - matrizInicial[i][j - 1]));
            }
            else
            {
                if (matrizInicial[i][j + 1] < matrizInicial[i][j])
                    nodosEncontrados.Add(new Nodo(
                        i,
                        j + 1,
                        matrizInicial[i][j] - matrizInicial[i][j + 1]));
            }

            return nodosEncontrados;
        }

        public List<List<int>> leerArchivo(string file)
        {
            var matrizLeida = new List<List<int>>();
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);

                matrizLeida = lines.Select(
                    l => l.Split(" ").Select(int.Parse).ToList()).ToList();

                matrizLeida = matrizLeida.Skip(1).ToList();

                //mostrarMatrizEnConsola(matrizLeida, "Matriz leída:");
            }
            return matrizLeida;
        }
    }
}

