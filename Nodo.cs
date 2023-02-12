using System;
namespace pruebaDesarrolloOscar
{
	public class Nodo
	{
		public Nodo(int x, int y, int edge)
		{
			fila = x;
			columna = y;
			distancia = edge;
			marcado = false;
			ruta = new List<int>();
			indiceNodoAnterior = 0;
			invalido = false;
		}
		public int fila { get; set; }
		public int columna { get; set; }
		public int distancia { get; set; }
		public bool marcado { get; set; }
        public List<int> ruta { get; set; }
		public int indiceNodoAnterior { get; set; }
		public bool invalido { get; set; }
	}
}

