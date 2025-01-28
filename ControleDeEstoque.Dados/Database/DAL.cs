using ControleDeEstoque.BancoDeDados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Database;
public class DAL<T> where T : class
{
    private readonly ControleDeEstoqueContext context;

    public DAL(ControleDeEstoqueContext context)
    {
        this.context = context;
    }

    public IEnumerable<T> List()
    {
        return context.Set<T>().ToList();
    }

    public void Create(T obj)
    {
        context.Set<T>().Add(obj);
        context.SaveChanges();
    }

    public void Update(T obj)
    {
        context.Set<T>().Update(obj);
        context.SaveChanges();
    }

    public void Delete(T obj)
    {
        context.Set<T>().Remove(obj);
        context.SaveChanges();
    }

    public T? GetFor(Func<T, bool> condition)
    {
        return context.Set<T>().FirstOrDefault(condition);
    }


}

