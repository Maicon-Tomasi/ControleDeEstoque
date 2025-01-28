using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class Estoque
{
    [Key]
    public int IdEstoque { get; set; }
    public string Nome { get; set; }
    public ICollection<EstoqueProduto> EstoqueProdutos { get; set; }

    public Estoque()
    {

    }

    // Construtor personalizado
    public Estoque(string nomeEstoque)
    {
        Nome = nomeEstoque;
    }
}

