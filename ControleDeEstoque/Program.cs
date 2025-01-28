
using ControleDeEstoque.Menu;
using ControleDeEstoque.Modelos;
using ControleDeEstoque.Database;
using ControleDeEstoque.BancoDeDados;


var context = new ControleDeEstoqueContext();
var estoqueDal = new DAL<Estoque>(context);
var produtoDal = new DAL<Produto>(context);
var fornecedorDal = new DAL<Fornecedor>(context);
var transportadoraDal = new DAL<Transportadora>(context);
var cidadeDal = new DAL<Cidade>(context);
var categoriaDal = new DAL<Categoria>(context);

Dictionary<int, string> categorias = new()
{
    { 1, "Opções de Estoque" },
    { 2, "Opções de Produtos" },
    { 3, "Opções de Fornecedoe" },
    { 4, "Opções de Transportadora" },
    { 5, "Opções de Cidade" },
    { 6, "Opções de Categoria" }, 
    { -1, "Sair" }
};


Dictionary<int, Menu> opcoesEstoque = new()
{
    { 1, new MenuCadastrarEstoque(context, estoqueDal) },
    { 2, new MenuListarEstoquesCadastrados(context, estoqueDal) },
    { 3, new MenuEditarEstoque(context, estoqueDal) },
    { 4, new MenuDeletarEstoque(context, estoqueDal) }
};

Dictionary<int, Menu> opcoesProdutos = new()
{
    { 1, new MenuCadastrarProduto(context, produtoDal) },
    { 2, new MenuListaProdutosCadastrados(context, produtoDal) },
    { 3, new MenuEditarProduto(context, produtoDal) },
    { 4, new MenuDeletarProduto(context, produtoDal) }
};

Dictionary<int, Menu> opcoesFornecedor = new()
{
    { 1, new MenuCadastrarFornecedor(context, fornecedorDal) },
    { 2, new MenuListarFornecedores(context, fornecedorDal) },
    { 3, new MenuEditarFornecedores(context, fornecedorDal) },
    { 4, new MenuDeletarFornecedor(context, fornecedorDal) }
};

Dictionary<int, Menu> opcoesTransportadora = new()
{
    { 1, new MenuCadastrarTransportador(context, transportadoraDal) },
    { 2, new MenuListarTransportadoras(context, transportadoraDal) },
    { 3, new MenuEditarTransportadoras(context, transportadoraDal) },
    { 4, new MenuDeletarTransportadora(context, transportadoraDal) }
};

Dictionary<int, Menu> opcoesCidade = new()
{
    { 1, new MenuCadastrarCidade(context, cidadeDal) },
    { 2, new MenuListarCidadesCadastradas(context, cidadeDal) },
    { 3, new MenuEditarCidade(context, cidadeDal) },
    { 4, new MenuDeletarCidade(context, cidadeDal) }
};

Dictionary<int, Menu> opcoesCategorias = new()
{
    { 1, new MenuCadastrarCategoria(context, categoriaDal) },
    { 2, new MenuListarCategorias(context, categoriaDal) },
    { 3, new MenuEditarCategoria(context, categoriaDal) },
    { 4, new MenuDeletarCategoria(context, categoriaDal) }
};

Dictionary<int, string> descricoesProdutos = new()
{
    { 1, "Cadastrar Produto" },
    { 2, "Listar Produtos Cadastrados" },
    { 3, "Editar Produtos" },
    { 4, "Deletar Produto"}
};

Dictionary<int, string> descricoesEstoque = new()
{
    { 1, "Cadastrar Estoque" },
    { 2, "Listar Estoques Cadastrados" },
    { 3, "Editar Estoque" },
    { 4, "Deletar Estoque" }
};

Dictionary<int, string> descricoesFornecedor = new()
{
    { 1, "Cadastrar Fornecedor" },
    { 2, "Listar Fornecedores Cadastrados" },
    { 3, "Editar Fornecedor" },
    { 4, "Deletar Fornecedor" }
};


Dictionary<int, string> descricoesTransportadora = new()
{
    { 1, "Cadastrar Transportadora" },
    { 2, "Listar Transportadora Cadastradas" },
    { 3, "Editar Transportadora" },
    { 4, "Deletar Transportadora" }
};

Dictionary<int, string> descricoesCidade = new()
{
    { 1, "Cadastrar Cidade" },
    { 2, "Listar Cidades Cadastradas" },
    { 3, "Editar Cidade" },
    { 4, "Deletar Cidade" }
};

Dictionary<int, string> descricoesCategoria = new()
{
    { 1, "Cadastrar Categoria" },
    { 2, "Listar Categoria Cadastradas" },
    { 3, "Editar Categoria" },
    { 4, "Deletar Categoria" }
};



void ExibirLogo()
{
    Console.WriteLine(@"

 _____                _                 _             _                    _                              
/  __ \              | |               | |           | |                  | |                             
| /  \/  ___   _ __  | |_  _ __   ___  | |  ___    __| |  ___    ___  ___ | |_   ___    __ _  _   _   ___ 
| |     / _ \ | '_ \ | __|| '__| / _ \ | | / _ \  / _` | / _ \  / _ \/ __|| __| / _ \  / _` || | | | / _ \
| \__/\| (_) || | | || |_ | |   | (_) || ||  __/ | (_| ||  __/ |  __/\__ \| |_ | (_) || (_| || |_| ||  __/
 \____/ \___/ |_| |_| \__||_|    \___/ |_| \___|  \__,_| \___|  \___||___/ \__| \___/  \__, | \__,_| \___|
                                                                                          | |             
                                                                                          |_|     
");
    Console.WriteLine("Bem-vindo ao sistema de Controle de Estoque!");
}


void ExibirMenuPrincipal()
{
    Console.Clear();
    ExibirLogo();

    Console.WriteLine("\nMenu Principal:");
    foreach (var categoria in categorias)
    {
        Console.WriteLine($"Digite {categoria.Key} para {categoria.Value}");
    }

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (categorias.ContainsKey(opcaoEscolhidaNumerica))
    {
        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                ExibirSubmenu("Estoque", opcoesEstoque, descricoesEstoque);
                break;
            case 2:
                ExibirSubmenu("Produtos", opcoesProdutos, descricoesProdutos);
                break;
            case 3:
                ExibirSubmenu("Fornecedores", opcoesFornecedor, descricoesFornecedor);
                break;
            case 4:
                ExibirSubmenu("Transportadora", opcoesTransportadora, descricoesTransportadora);
                break;
            case 5:
                ExibirSubmenu("Cidades", opcoesCidade, descricoesCidade);
                break;
            case 6:
                ExibirSubmenu("Categorias", opcoesCategorias, descricoesCategoria);
                break;
            case -1:
                Console.WriteLine("Saindo do sistema...");
                return;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }

    }
    else
    {
        Console.WriteLine("Opção inválida.");
    }

    ExibirMenuPrincipal(); // Retorna ao menu principal após a execução
}

void ExibirSubmenu(string nomeCategoria, Dictionary<int, Menu> opcoes, Dictionary<int, string> descricoes)
{
    Console.Clear();
    Console.WriteLine($"\n{nomeCategoria}:");

    foreach (var opcao in opcoes)
    {
        // Use a descrição associada à opção
        string descricao = descricoes.ContainsKey(opcao.Key) ? descricoes[opcao.Key] : "Opção Desconhecida";
        Console.WriteLine($"Digite {opcao.Key} para {descricao}");
    }
    Console.WriteLine("Digite 0 para voltar ao menu principal.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        var menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar();
    }
    else if (opcaoEscolhidaNumerica == 0)
    {
        return; // Volta ao menu principal
    }
    else
    {
        Console.WriteLine("Opção inválida.");
    }

    ExibirSubmenu(nomeCategoria, opcoes, descricoes); // Retorna ao submenu após a execução
}


ExibirMenuPrincipal();

