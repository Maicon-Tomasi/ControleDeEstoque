using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class ItemDeEntrada
{
    public int Id { get; set; }
    public string Lote { get; set; }
    public float Quantidade { get; set; }
    public float QuantidadeOriginal { get; set; }
    public float Valor { get; set; }
    public int IdProduto { get; set; }
    public int? IdFornecedor { get; set; }
    public DateTime DataEntrada { get; set; }
    public Produto Produto { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public ICollection<EstoqueProduto> Estoques { get; set; }



    public ItemDeEntrada() { }

    public ItemDeEntrada(string lote, float quantidade, float valor, Produto produto)
    {
        Lote = lote;
        Quantidade = quantidade;
        Valor = valor;
        Produto = produto;
    }
}

