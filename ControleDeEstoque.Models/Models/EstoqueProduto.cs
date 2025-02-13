using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class EstoqueProduto
{
    public int Id { get; set; }
    public int IdEstoque { get; set; }
    public int IdItemDeEntrada { get; set; }
    public Estoque Estoque { get; set; }
    public ItemDeEntrada ItemDeEntrada { get; set; }
}


