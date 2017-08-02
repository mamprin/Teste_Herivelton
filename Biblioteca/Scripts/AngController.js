app.controller("AngLivroController", function ($scope, AngLivroServices) {

    $scope.divLivro = false;
    GetTodosLivros();

    function GetTodosLivros() {

        var getListaLivros = AngLivroServices.getTodos();

        getListaLivros.then(function (livro) {

            // Caso exista não exista dados na lista exibe mensagem
            if (livro.data.length == 0) {
                $scope.divVazio = true;
                $scope.divLista = false;
            } else {
                $scope.divVazio = false;
                $scope.divLista = true;

                // $scope recebe os itens retornados do banco 
                $scope.Livros = livro.data;
            }
        }, function () {
            alert('Não foi possível recuperar a lista de Livros.');
        });
    }

    // Editar dados do Livro
    $scope.editarLivro = function (livro) {
        var getDadosLivro = AngLivroServices.getLivroId(livro.IdLivro);

        getDadosLivro.then(function (livro) {
            // Recupera os dados informados
            $scope.Livro = livro.data;
            $scope.IdLivro = livro.data.IdLivro;
            $scope.NomeLivro = livro.data.NomeLivro;
            $scope.Autor = livro.data.Autor;
            $scope.Editora = livro.data.Editora;

            // Define a ação
            $scope.Action = "Alterar";
            $scope.divLivros = true;

        }, function () {
            alert("Erro ao tentar obter registros do Livro.");
        });
    }

    // Atualiza ou Inclui o Livro
    $scope.AdicionarAtualizarLivro = function () {

        var Livro = {
            NomeLivro: $scope.NomeLivro,
            Autor: $scope.Autor,
            Editora: $scope.Editora
        };

        var getLivroAction = $scope.Action;

        // Valida o tipo de ação a ser tomada
        if (getLivroAction == "Alterar") {
            Livro.IdLivro = $scope.IdLivro;

            // Realiza o acesso a Controller
            var getDadosLivro = AngLivroServices.AlterarLivro(Livro);

            getDadosLivro.then(function (msg) {

                GetTodosLivros();
                alert(msg.data);
                LimpaCampos();
                $scope.divLivros = false;


            }, function () {
                alert("Erro ao tentar editar os dados do Livro.");
            });

        } else {
            var getDadosLivro = AngLivroServices.AdicionarLivro(Livro);

            getDadosLivro.then(function (msg) {
                GetTodosLivros();
                alert(msg.data);
                LimpaCampos();
                $scope.divLivros = false;
            }, function () {
                alert("Erro ao tentar incluir o livro.");
            });
        }
    };

    // Excluir dados do Livro
    $scope.deletarLivro = function (livro) {
        $scope.divLivros = false;
        var getDadosLivro = AngLivroServices.ExcluirLivro(livro.IdLivro);

        getDadosLivro.then(function (msg) {
            GetTodosLivros();
            alert(msg.data);
            LimpaCampos();
            
        }, function () {
            alert("Erro ao tentar remover os dados do Livro.");
        });
    }
    
    // Define a div
    $scope.AdicionarLivroDiv = function () {
        LimpaCampos();
        $scope.Action = "Adicionar";
        $scope.divLivros = true;
    }

    // Limpa os campos
    function LimpaCampos() {
        $scope.IdLivro = "";
        $scope.NomeLivro = "";
        $scope.Autor = "";
        $scope.Editora = "";
    };

    // Cancela a operação
    $scope.Cancel = function () {
        $scope.divLivros = false;
    };

});