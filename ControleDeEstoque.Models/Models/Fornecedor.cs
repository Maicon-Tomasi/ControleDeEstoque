using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class Fornecedor
{
    public int Id { get; set; }
    public string NomeFornecedor { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public int Cep { get; set; }
    public string Documento { get; set; }
    public string Telefone { get; set; }
    public int? CidadeId { get; set; }
    public Cidade Cidade { get; set; }
    public ICollection<FornecedorProdutos> Produtos { get; set; }
    public ICollection<ItemDeEntrada> FornecedorEntrada { get; set; }




    public Fornecedor() { }
    public Fornecedor(string fornecedor, string endereco, string numero, string bairro, int cep, string documento, string telefone, int idCidade) 
    { 
        NomeFornecedor = fornecedor;
        Endereco = endereco;
        Numero = numero;
        Bairro = bairro;
        Cep = cep;
        Documento = documento;
        Telefone = telefone;
        CidadeId = idCidade;
    }
}

