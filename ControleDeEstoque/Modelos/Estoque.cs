using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Estoque
{
    public int Id { get; set; }
    public string NomeEstoque { get; set; }

    public Estoque(string nome) 
    {
        NomeEstoque = nome;
    }
}

