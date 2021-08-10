using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Veiculos.Domain.Interfaces.Repositories.Base;

namespace Veiculos.Domain.Services.Base
{
    public class BaseService<TEntity> : IDisposable, Interfaces.Services.Base.IBaseService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        public BaseService(IBaseRepository<TEntity> repository) => _repository = repository;
        public virtual async Task<IList<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] pPropriedades)
            => await _repository.ListarTodosAsync(where, pPropriedades);
        public virtual async Task<IList<TEntity>> ListarTodos(params Expression<Func<TEntity, object>>[] Propriedades)
            => await _repository.ListarTodos(Propriedades);
        public virtual async Task<bool> Adiciona(TEntity modelo) =>
            await _repository.Adiciona(modelo);
        public virtual async Task<bool> Atualiza(TEntity modelo) =>
            await _repository.Atualiza(modelo);
        public virtual async Task<bool> Exclui(TEntity modelo) =>
            await _repository.Exclui(modelo);
        
        public virtual void Dispose() => _repository.Dispose();
    }
}
