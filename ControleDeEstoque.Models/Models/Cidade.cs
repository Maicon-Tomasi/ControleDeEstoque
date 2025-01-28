using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class Cidade
{
    public int Id { get; set; }
    public string NomeCidade { get; set; }
    public string Estado { get; set; }

    public ICollection<Transportadora> Transportadoras { get; set; }

    public ICollection<Fornecedor> Fornecedores { get; set; }

    public Cidade() { }

    public Cidade(string nomeCidade, string estado)
    {
        NomeCidade = nomeCidade;
        Estado = estado;
    }
}

