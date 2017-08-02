using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    /// <summary>
    /// Classe Livros
    /// </summary>
    public class Livros
    {
        [Key]
        public int IdLivro { get; set; }

        public string NomeLivro { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }
    }
}