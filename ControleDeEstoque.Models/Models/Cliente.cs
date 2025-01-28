using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class Cliente
{
    public int Id { get; set; }
    public string NomeDoCliente { get; set; }
    public string Endereco { get; set; }
    public int Num { get; set; }
    public string Bairro { get; set; }
    public string Tel { get; set; }
    public string Documento { get; set; }
    public Cidade Cidade { get; set; }

    public Cliente() { }

    public Cliente(string nome, string endereco, int num, string bairro, string tel, string documento, Cidade cidade)
    {
        NomeDoCliente = nome;
        Endereco = endereco;
        Num = num;
        Bairro = bairro;
        Tel = tel;
        Documento = documento;
        Cidade = cidade;
    }

}

