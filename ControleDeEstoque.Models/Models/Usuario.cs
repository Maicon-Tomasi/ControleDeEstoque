using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cpf { get; set; }

    public Usuario(string nome, string email, string senha, string cpf) 
    { 
        Nome = nome;
        Email = email;
        Senha = senha;
        Cpf = cpf;
    }

}

