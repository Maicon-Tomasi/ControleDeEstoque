using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Categoria
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Categoria(string descricao)
    {
        Descricao = descricao;
    }
}

