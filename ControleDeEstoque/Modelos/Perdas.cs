using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Perdas
{
    public int Id { get; set; }
    public float Quantidade { get; set; }
    public string Descricao { get; set; }
    public Produto Produto { get; set; }

    public Perdas(float quantidade, string descricao, Produto produto)
    {
        Quantidade = quantidade;
        Descricao = descricao;
        Produto = produto;
    }
}

