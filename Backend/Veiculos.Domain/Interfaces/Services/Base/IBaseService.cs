using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Veiculos.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> ListarTodos(params Expression<Func<TEntity, object>>[] Propriedades);
        Task<IList<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] pPropriedades);
        Task<bool> Adiciona(TEntity modelo);
        Task<bool> Atualiza(TEntity modelo);
        Task<bool> Exclui(TEntity modelo);

        void Dispose();
    }
}
