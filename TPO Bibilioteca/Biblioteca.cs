using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPO_Bibilioteca
{
    internal class Biblioteca
    {
        private List<Libro> librosRegistrados;
        private List<Lector> lectoresRegistrados;

        public Biblioteca()
        {
            this.librosRegistrados = new List<Libro> ();
            this.lectoresRegistrados = new List<Lector> ();
        }

        public Libro buscarLibro(string titulo)
        {
            foreach (var libro in librosRegistrados)
            {
                if (libro.getTitulo().Equals(titulo))
                {
                    return libro;
                }
            }
            return null;
        }
        public void listarLibros()
        {
            Console.WriteLine("*** Listado de Libros ***\n");
            foreach (var libro in librosRegistrados)
            {
                Console.WriteLine(libro);
                Console.WriteLine("---------------");
            }

        }
        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro libro = buscarLibro(titulo);

            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                librosRegistrados.Add(libro);
                resultado = true;
            }
            Console.WriteLine(resultado
            ? $"Libro: {titulo} agregado correctamente."
            : $"Libro: {titulo} ya existe.");
            return resultado;
        }
        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro libro = buscarLibro(titulo);
            if ( libro != null)
            {
                librosRegistrados.Remove(libro);
                resultado = true;
            }
            return resultado;
        }

        public string prestarLibro(string tituloLibro, string dniLector)
        {
            Libro libro = buscarLibro(tituloLibro);
            if (libro == null) return "LIBRO INEXISTENTE";

            Lector lector = buscarLector(dniLector);
            if (lector == null) return "LECTOR INEXISTENTE";

            if (!lector.puedePedirPrestado()) return "TOPE DE PRÉSTAMO ALCANZADO";

            librosRegistrados.Remove(libro);
            lector.agregarLibro(libro);
            return "PRÉSTAMO EXITOSO";
        }
        public string reponerLibro(string tituloLibro, string dniLector)
        {
            Lector lector = buscarLector(dniLector);
            if (lector == null) return "LECTOR INEXISTENTE";
           
            Libro libroDevuelto = lector.devolverLibro(tituloLibro);
            librosRegistrados.Add(libroDevuelto);

            return "LIBRO DEVUELTO EXITOSAMENTE";
        }
        public Lector buscarLector(string dni)
        {
            foreach (var lector in lectoresRegistrados)
            {
                if (lector.getDNI().Equals(dni))
                {
                    return lector;
                }
            }
            return null;
        }
        public bool altaLector(string nombre, string dni)
        {
            if (buscarLector(dni) != null) return false;

            lectoresRegistrados.Add(new Lector(nombre, dni));
            return true;
        }
        public void listarLectores()
        {
            Console.WriteLine("*** Listado de lectores ***\n");
            foreach (var lector in lectoresRegistrados)
            {
                Console.WriteLine(lector);
                Console.WriteLine("---------------");
            }
                
        }
        public bool eliminarLector(string dni)
        {
            bool resultado = false;
            Lector lector = buscarLector(dni);
            if (lector != null)
            {
                lectoresRegistrados.Remove(lector);
                resultado = true;
            }
            return resultado;
        }
    }
}
