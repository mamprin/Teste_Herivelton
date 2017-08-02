using System.Data.Entity;

namespace Biblioteca.Models
{
    /// <summary>
    /// Context para a classe Livros
    /// </summary>
    public class Livro_Context : DbContext
    {
        public Livro_Context()
            : base ("Biblioteca_Livros"){ }

        public DbSet<Livros> livros { get; set; }

    }
}