using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Regras.Interface
{
    public class Cadastro<T> : IDisposable, ICadastro<T> where T : class
    {
        private String mensagem;
        public T Alterado;
        public SiteContexto dados;

        public Cadastro()
        {
            dados = RepositorioDados.Instanciar(false);
        }

        public Cadastro(bool exclui)
        {
            dados = RepositorioDados.Instanciar(exclui);
        }

        public bool Incluir(T entidade)
        {
            try
            {
                dados.Set<T>().Add(entidade);
                dados.SaveChanges();
            }
            catch (Exception erro)
            {
                LancaErro(erro);
            }
            return true;
        }

        public T Retorna(int id)
        {
            return dados.Set<T>().Find(id);
        }

        public bool Excluir(int id)
        {
            try
            {
                T item = dados.Set<T>().Find(id);
                dados.Set<T>().Remove(item);
                dados.SaveChanges();
            }
            catch (Exception erro)
            {
                LancaErro(erro);
            }

            return true;
        }

        public virtual List<T> RetornaTodos()
        {
            return dados.Set<T>().ToList();
        }

        public bool Alterar(int id)
        {
            try
            {
                T item = dados.Set<T>().Find(id);
                dados.Entry(item).State = EntityState.Modified;
                dados.SaveChanges();
            }
            catch (Exception erro)
            {
                LancaErro(erro);
            }

            return true;
        }

        public virtual void LancaErro(Exception erro)
        {
            throw new Exception(erro.Message);
        }

        public void Dispose()
        {
            dados.Dispose();
        }

        public void Editar(T item)
        {
            dados.Entry(item).State = EntityState.Modified;
            dados.SaveChanges();
        }

        public IQueryable<T> ObterTodos()
        {
            return dados.Set<T>();
        }

        public IQueryable<T> Buscar(Expression<Func<T,bool>> parametros )
        {
            return dados.Set<T>().Where(parametros);
        }

        public virtual List<T> FiltrarPorCodigo(int codigo)
        {
            return dados.Set<T>().ToList();
        }

        public virtual List<T> FiltrarPorNome(string nome)
        {
            return dados.Set<T>().ToList();
        }

        public virtual List<T> FiltrarNomeContem(string nome)
        {
            return dados.Set<T>().ToList();
        }
    }
}
