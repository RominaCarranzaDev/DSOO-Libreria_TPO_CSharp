using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPO_Biblioteca
{
    internal class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;

        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }

        public string getTitulo() { return titulo; }

        public string Autor => autor;
        public string Editorial => editorial;

        public override string ToString() {
            return $"Título: {titulo} \nAutor: {Autor} \nEditorial: {Editorial}";
        }
    }
}
