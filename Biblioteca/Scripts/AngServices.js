app.service("AngLivroServices", function ($http) {

    // Obtem todos os Livros
    this.getTodos = function () {
        var response = $http({
            method: 'GET',
            url: 'api/Livro/ListaLivros'
        });

        return response;
    };

    // Obtem Livro por ID
    this.getLivroId = function (id_Livro) {
        var response = $http({
            method: "GET",
            params: {
                idLivro: JSON.stringify(id_Livro)
            },
            url: "api/Livro/ListaLivrosPorId/"
        });
        return response;
    };

    // Rotina para realizar a chamada a controller para alteração
    this.AlterarLivro = function (livro) {
        var response = $http({
            method: "PUT",
            data: livro,
            url: "api/Livro/EditarLivro/"

        });
        return response;
    };

    // Rotina que realiza a chamada da controller para a inclusão
    this.AdicionarLivro = function (livro) {
        var response = $http({
            method: "POST",
            data: livro,
            url: "api/Livro/AdicionarLivro/"
        });
        return response;
    };

    // Rotina que realiza a chamada da controller
    this.ExcluirLivro = function (id_livro) {
        var response = $http({
            method: "DELETE",
            url: "api/Livro/ExcluirLivro/",
            params: {
                idLivro: JSON.stringify(id_livro)
            }
        });
        return response;
    };
});
