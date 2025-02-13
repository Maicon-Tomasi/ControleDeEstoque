using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class Produto
{
    [Key]
    public int Id { get; set; }
    public string CodigoProduto { get; set; }
    public string NomeProduto { get; set; }
    public string DescricoDoProduto { get; set; }
    public string UnidadeDeMedida { get; set; }
    public string TempoDeVencimento { get; set; }
    public int? IdCategoriaProduto { get; set; }

    //public ICollection<EstoqueProduto> EstoqueProdutos { get; set; }
    public Categoria Categoria { get; set; }
    public ICollection<FornecedorProdutos> Fornecedores { get; set; }
    public ICollection<ItemDeEntrada> ProdutosEntrada { get; set; }
    public ICollection<ItemDeSaida> ProdutosSaida { get; set; }


    public Produto() { }

    public Produto(string codigoProduto, string nomeProduto, string descricoDoProduto, string unidadeDeMedida, string tempoDeVencimento)
    {
        CodigoProduto = codigoProduto;
        NomeProduto = nomeProduto;
        DescricoDoProduto = descricoDoProduto;
        UnidadeDeMedida = unidadeDeMedida;
        TempoDeVencimento = tempoDeVencimento;
    }
}
