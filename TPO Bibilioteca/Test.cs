using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPO_Bibilioteca;

class Test
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        CargarLibros(biblioteca);
        CargarLectores(biblioteca);
        MenuPrincipal(biblioteca);
    }

    static void CargarLibros(Biblioteca b)
    {
        var libros = new List<(string titulo, string autor, string editorial)>
        {
            ("Harry Potter y la Orden del Fénix","J. K. Rowling","Salamandra"),
            ("El Hobbit", "Tolkien", "Minotauro"),
            ("1984", "Orwell", "Planeta"),
            ("Dune", "Herbert", "Debolsillo"),
            ("El duelo. Cuando el dolor se hace carne","Gabriel Rolón","Planeta"),
            ("Lecciones De Juventud","Danielle Steel","Plaza & Janés"),
            ("El asesino ciego","Margaret Atwood","Margaret Atwood"),
            ("Del Amor Y Otros Demonios","Gabriel García Márquez","Literatura Random House"),
            ("Fahrenheit 451","Ray Bradbury","Minotauro"),
            ("El fin de la eternidad","Isaac Asimov","Debolsillo"),
            ("Cien años de soledad","Gabriel García Márquez", "Alfaguara"),
            ("El alquimista","Paulo Coelho","Planeta")

        };
        foreach (var l in libros)
        {
            bool pude;
            pude = b.agregarLibro(l.titulo, l.autor, l.editorial);
            if (!pude)
            {
                Console.WriteLine($"Libro: {l.titulo} ya existe.");
            }
        }
        Console.WriteLine($"*** Libros cargados correctamente. ****");
    }

    static void CargarLectores(Biblioteca b)
    {
        var lectores = new List<(string nombre, string dni)>
        {
            ("Anthony", "12345678"),
            ("Benedict", "11223344"),
            ("Collin", "44446688"),
            ("Dafne", "298908002"),
            ("Eloise", "12123344"),
            ("Franchesca", "32132456"),
            ("Gregory", "44567111"),
            ("Hyacinth", "555789990")
        };
        foreach (var l in lectores)
        {
            bool pude;
            pude = b.altaLector(l.nombre, l.dni);
            Console.WriteLine(pude
            ? $"Lector: {l.nombre} agregado correctamente."
            : $"Lector: {l.nombre} ya existe.");
        }
    }

    static void MenuPrincipal(Biblioteca b)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n*** BIBLIOTECA ***");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Lectores");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("0. Salir");
            Console.WriteLine("\nSeleccione una opción:");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 3)
            {
                Console.WriteLine("Error: Opción inválida.\nSeleccione una opcion:");

            }

            switch (opcion)
            {
                case 1:
                    MenuLibros(b);
                    break;
                case 2:
                    MenuLectores(b);
                    break;
                case 3:
                    MenuPrestamos(b);
                    break;
            }

        } while (opcion != 0);
        Console.WriteLine("\n***************\nCerrando App Biblioteca\n***************");
    }
    static void MenuLibros(Biblioteca b)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n*** LIBROS ***");
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("0. Volver");
        
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 3)
            {
                Console.WriteLine("Error: Opción inválida.\nSeleccione una opción:");

            }
            switch (opcion)
            {
                case 1:
                    b.listarLibros();
                    break;
                case 2:
                    Console.WriteLine("Ingrese los siguientes datos del libro.");
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();

                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();

                    Console.Write("Editorial: ");
                    string editorial = Console.ReadLine();

                    Console.WriteLine(
                        b.agregarLibro(titulo, autor, editorial)
                        ? "Libro agregado correctamente."
                        : "No se puede agregar, el libro ya existe."
                    );
                    break;

                case 3:
                    Console.Write("Título a eliminar: ");
                    titulo = Console.ReadLine();

                    Console.WriteLine(
                        b.eliminarLibro(titulo)
                        ? "Libro eliminado correctamente."
                        : "Libro no encontrado!"
                    );
                    break;
            }
        } while (opcion != 0);
    }
    static void MenuLectores(Biblioteca b)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n*** LECTORES ***");
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Alta");
            Console.WriteLine("0. Volver");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 2)
            {
                Console.WriteLine("Error: Opción inválida.\nSeleccione una opción: ");

            }

            switch (opcion)
            {
                case 1:
                    b.listarLectores();
                    break;
                case 2:
                    Console.WriteLine("Ingrese los siguientes datos del lector.");
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("DNI: ");
                    string dni = Console.ReadLine();

                    Console.WriteLine(
                        b.altaLector(nombre, dni)
                        ? "Lector agregado correctamente."
                        : "El lector ya existe."
                    );
                    break;
            }
        } while (opcion != 0);
    }
    static void MenuPrestamos(Biblioteca b)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n*** PRÉSTAMOS ***\n");
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Prestar libro");
            Console.WriteLine("2. Devolver libro");
            Console.WriteLine("0. Volver");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 2)
            {
                Console.WriteLine("Error: Opcion invalida.\nSeleccione una opcion:");

            }

            Console.Write("Ingrese el DNI del lector: ");
            string dni = Console.ReadLine();

            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine();

            switch (opcion)
            {
                case 1:
                    Console.WriteLine(b.prestarLibro(titulo, dni));
                    opcion = 0;
                    break;

                case 2:
                    Console.WriteLine(b.reponerLibro(titulo, dni));
                    opcion = 0;
                    break;
            }
        } while (opcion != 0);
    }
}