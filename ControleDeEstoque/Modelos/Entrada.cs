using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelos;
internal class Entrada
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public DateTime DataEntrega { get; set; }
    public float Total { get; set; }
    public int NumNotaFiscal { get; set; }
    public Transportadora Transportadora { get; set; }

    public Entrada(DateTime dataPedido, DateTime dataEntrega, float total, int numNotaFiscal, Transportadora transportadora) 
    { 
        DataPedido = dataPedido;
        DataEntrega = dataEntrega;
        Total = total;
        NumNotaFiscal = numNotaFiscal;
        Transportadora = transportadora;
    }
}

