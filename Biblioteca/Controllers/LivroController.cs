using Biblioteca.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Biblioteca.Controllers
{
    /// <summary>
    /// API Controller
    /// </summary>
    public class LivroController : ApiController
    {
        /// <summary>
        /// Método que retorna a lista de livros
        /// </summary>
        /// <returns>Lista Ordenada por Nome</returns>
        [AcceptVerbs("GET")]
        public IOrderedEnumerable<Livros> ListaLivros()
        {
            using (Livro_Context contextLivros = new Livro_Context())
            {
                // Recupera a lista ordenada de livros 
                var listaLivros = contextLivros.livros.ToList().OrderBy(a => a.NomeLivro);

                // Retorna a lista
                return listaLivros;
            }
        }

        /// <summary>
        /// Método que retorna a lista de livros filtrando por ID
        /// </summary>
        /// <param name="item">ID do livro selecionado na lista</param>
        /// <returns>Item recuperado na busca</returns>
        [AcceptVerbs("GET")]
        public Livros ListaLivrosPorId(string idLivro)
        {
            using (Livro_Context contextLivros = new Livro_Context())
            {
                // Recupera a lista ordenada de livros 
                var livro = contextLivros.livros.Find(Int32.Parse(idLivro));

                // Retorna a lista
                return livro;
            }
        }
        
        /// <summary>
        /// Método que realiza a inclusão do livro no banco de dados
        /// </summary>
        /// <param name="item">Parâmetro enviado pelo usuário</param>
        /// <returns>Retorna mensagem para o usuário</returns>
        [AcceptVerbs("POST")]
        public string AdicionarLivro(Livros item)
        {
            // Valida se o item não está nulo
            if (item != null)
            {
                using (Livro_Context contextLivro = new Livro_Context())
                {
                    try
                    {
                        // Adiciona o livro ao banco de dados
                        contextLivro.livros.Add(item);

                        // Salva as modificações
                        contextLivro.SaveChanges();

                        // Retorna mensagem para o usuário
                        return "Livro cadastrado com sucesso.";
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                // Retorna mensagem para o usuário
                return "Não foi possível cadastrar o livro";
            }
        }

        /// <summary>
        /// Método que realiza a alteração do livro selecionado
        /// </summary>
        /// <param name="item">Parâmetro enviado para a busca do livro</param>
        /// <returns>Retorna mensagem para o usuário</returns>
        [AcceptVerbs("PUT")]
        public string EditarLivro(Livros item)
        {
            // Valida se o item não está nulo ou o ID não está zerado
            if (item != null || item.IdLivro != 0)
            {
                using (Livro_Context contextLivro = new Livro_Context())
                {
                    try
                    {
                        // Recebe o id do livro a ser editado
                        int livroId = Convert.ToInt32(item.IdLivro);

                        // Busca o livro utilizando o ID recebido
                        Livros livro = contextLivro.livros.Where(a => a.IdLivro == livroId).FirstOrDefault();

                        // Realiza as alterações no Livro encontrado
                        livro.NomeLivro = item.NomeLivro.Trim();
                        livro.Autor = item.Autor.Trim();
                        livro.Editora = item.Editora.Trim();

                        // Salva as alterações
                        contextLivro.SaveChanges();

                        // Retorna mensagem para o usuário
                        return "Livro alterado com sucesso.";
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

            }
            else
            {
                // Retorna mensagem para o usuário
                return "Não foi possível realizar a alteração.";
            }
        }

        /// <summary>
        /// Método que realiza a exclusão do livro selecionado
        /// </summary>
        /// <param name="IdLivro">Parâmetro para realizar a busca do livro a ser excluído</param>
        /// <returns>Retorna mensagem para o usuário</returns>
        [AcceptVerbs("DELETE")]
        public string ExcluirLivro(string IdLivro)
        {
            // Valida se o item está nulo ou vazio
            if (!String.IsNullOrEmpty(IdLivro))
            {
                using (Livro_Context contextLivro = new Livro_Context())
                {
                    // Realiza a busca do livro selecionado
                    var livro = contextLivro.livros.Find(Int32.Parse(IdLivro));

                    // Remove o livro encontrado através do ID
                    contextLivro.livros.Remove(livro);

                    // Salva a alteração
                    contextLivro.SaveChanges();

                    // Retorna mensagem
                    return "Livro selecionado excluído com sucesso.";
                }
            }
            else
            {
                // Retorna mensagem
                return "Não foi possível excluir o livro selecionado.";
            }
        }

    }
}
