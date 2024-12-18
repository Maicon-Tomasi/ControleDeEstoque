using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Fornecedor
{
    public int Id { get; set; }
    public string NomeFornecedor { get; set; }
    public string Endereco { get; set; }
    public int Numero { get; set; }
    public string Bairro { get; set; }
    public int Cep { get; set; }
    public string Documento { get; set; }
    public string Telefone { get; set; }
    public Cidade Cidade { get; set; }

    public Fornecedor(string fornecedor, string endereco, int numero, string bairro, int cep, string documento, string telefone, Cidade cidade) 
    { 
        NomeFornecedor = fornecedor;
        Endereco = endereco;
        Numero = numero;
        Bairro = bairro;
        Cep = cep;
        Documento = documento;
        Telefone = telefone;
        Cidade = cidade;
    }
}

