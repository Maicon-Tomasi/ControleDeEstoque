using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Produto
{
    public int Id { get; set; }
    public string codigoProduto { get; set; }
    public int NomeProduto { get; set; }
    public string DescricoDoProduto { get; set; }
    public DateTime Validade { get; set; }
    public string UnidadeDeMedida { get; set; }
    public  Categoria CategoriaDoProduto { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public Produto(string codigoProduto, int nomeProduto, string descricoDoProduto, DateTime validade, string unidadeDeMedida, Categoria categoriaDoProduto)
    {
        this.codigoProduto = codigoProduto;
        NomeProduto = nomeProduto;
        DescricoDoProduto = descricoDoProduto;
        Validade = validade;
        UnidadeDeMedida = unidadeDeMedida;
        CategoriaDoProduto = categoriaDoProduto;
    }
}
