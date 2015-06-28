using System.Collections.Generic;

namespace Regras.Interface
{
    public interface ICadastro<T> where T : class
    {
        bool Incluir(T entidade);

        T Retorna(int id);

        bool Excluir(int id);

        List<T> RetornaTodos();

        bool Alterar(int id);
    }
}