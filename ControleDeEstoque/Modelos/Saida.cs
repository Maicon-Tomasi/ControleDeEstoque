using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Saida
{
    public int Id { get; set; }
    public float Total { get; set; }
    public float Frete { get; set; }
    public float Imposto { get; set; }
    public Transportadora Transportadora { get; set; }

    public Saida(float total, float frete, float imposto, Transportadora transportadora)
    {
        Total = total;
        Frete = frete;
        Imposto = imposto;
        Transportadora = transportadora;
    }
}

