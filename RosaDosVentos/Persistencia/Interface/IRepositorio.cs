using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interface
{
    public interface IRepositorio<T> where T : class
    {
        void Incluir(T item);
        void Excluir(T item);
        void Excluir(object id);
        void Editar(T item);
        T Retorna(object id);
        IQueryable<T> RetornaTodos();
    }
}
