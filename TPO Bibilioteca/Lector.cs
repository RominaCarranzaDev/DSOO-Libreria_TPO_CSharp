using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPO_Bibilioteca
{
    internal class Lector
    {
        private string nombre;
        private string dni;
        private int maximoPrestamos;
        private List<Libro> librosPrestados;

        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.maximoPrestamos = 3;
            this.librosPrestados = new List<Libro>();
        }

        public string getDNI() => dni;

        public void agregarLibro(Libro libro)
        {
            librosPrestados.Add(libro);
        }

        public Libro devolverLibro(string libroTitulo)
        {
            Libro libroDevuelto = librosPrestados.Find(l => l.getTitulo().Equals(libroTitulo));

            if (libroDevuelto != null)
            {
                librosPrestados.Remove(libroDevuelto);
            }

            return libroDevuelto;
        }
        public bool puedePedirPrestado()
        {
            return librosPrestados.Count < maximoPrestamos;
        }
        public override string ToString()
        {
            return $"Lector: {nombre}\nDNI: {dni} \nCantidad de Libros Prestados: {librosPrestados.Count}\n";
        }
    }
}
