using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Transportadora
{
    public int Id { get; set; }
    public string NomeTransportadora { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public int Numero { get; set; }
    public int Cep { get; set; }
    public string Documento { get; set; }
    public string Contato { get; set; }
    public Cidade Cidade { get; set; }

    public Transportadora(string nomeTransportadora, string endereco, string bairro, int numero, int cep, string documento, string contato, Cidade cidade)
    {
        NomeTransportadora = nomeTransportadora;
        Endereco = endereco;
        Bairro = bairro;
        Numero = numero;
        Cep = cep;
        Documento = documento;
        Contato = contato;
        Cidade = cidade;
    }
}

