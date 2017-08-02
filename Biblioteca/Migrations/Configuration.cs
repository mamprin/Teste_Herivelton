namespace Biblioteca.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Biblioteca.Models.Livro_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Biblioteca.Models.Livro_Context";
        }

        protected override void Seed(Biblioteca.Models.Livro_Context context)
        {
           
        }
    }
}
