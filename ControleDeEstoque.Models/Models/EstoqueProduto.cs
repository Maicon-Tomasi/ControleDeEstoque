using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class EstoqueProduto
{
    public int Id { get; set; }
    public Estoque IdEstoque { get; set; }
    public Produto IdProduto { get; set; }
}


