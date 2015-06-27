using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Interface;

namespace Persistencia
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected readonly DbContext contexto;

        public Repositorio(DbContext contexto)
        {
            this.contexto = contexto;
        }

        public void Incluir(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
        }

        public void Excluir(T item)
        {
            contexto.Set<T>().Remove(item);
            contexto.SaveChanges();
        }

        public void Excluir(object id)
        {
            T item = contexto.Set<T>().Find(id);
            contexto.Set<T>().Remove(item);
            contexto.SaveChanges();
        }

        public void Editar(T item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public T Retorna(object id)
        {
            return contexto.Set<T>().Find(id);
        }

        public IQueryable<T> RetornaTodos()
        {
            return contexto.Set<T>();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }

    public class RepositorioDados
    {
        private static SiteContexto _contexto;

        public static SiteContexto Instanciar(bool exclui)
        {
            return _contexto ?? (_contexto = new SiteContexto(exclui));
        }
    }
}
