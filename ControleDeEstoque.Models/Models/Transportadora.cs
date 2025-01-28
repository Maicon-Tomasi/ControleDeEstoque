using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class Transportadora
{
    public int Id { get; set; }
    public string NomeTransportadora { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public int Cep { get; set; }
    public string Documento { get; set; }
    public string Contato { get; set; }
    public int? IdCidade { get; set; }

    public Cidade Cidade { get; set; }

    public Transportadora() { }
    public Transportadora(string nomeTransportadora, string endereco, string bairro, string numero, int cep, string documento, string contato, int cidade)
    {
        NomeTransportadora = nomeTransportadora;
        Endereco = endereco;
        Bairro = bairro;
        Numero = numero;
        Cep = cep;
        Documento = documento;
        Contato = contato;
        IdCidade = cidade;
    }
}

