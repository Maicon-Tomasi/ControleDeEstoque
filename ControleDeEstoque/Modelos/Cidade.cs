using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Cidade
{
    public int Id { get; set; }
    public string NomeCidade { get; set; }
    public string Estado { get; set; }

    public Cidade(string cidade, string estado)
    {
        NomeCidade = cidade;
        Estado = estado;
    }
}

