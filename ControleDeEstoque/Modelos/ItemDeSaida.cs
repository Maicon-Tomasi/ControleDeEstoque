using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class ItemDeSaida
{
    public int Id { get; set; }
    public string Lote { get; set; }
    public float Quantidade { get; set; }
    public float Valor { get; set; }
    public Produto Produto { get; set; }

    public ItemDeSaida(string lote, float quantidade, float valor, Produto produto)
    {
        Lote = lote;
        Quantidade = quantidade;
        Valor = valor;
        Produto = produto;
    }
}

