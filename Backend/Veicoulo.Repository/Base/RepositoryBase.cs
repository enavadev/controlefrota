using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Veicoulo.Repository.Base
{
    public class RepositoryBase<TEntity> : IDisposable,
           Veiculos.Domain.Interfaces.Repositories.Base.IBaseRepository<TEntity>
           where TEntity : class
    {
        protected readonly Veiculos.Data.Context.BaseContext _context;
        public RepositoryBase(Veiculos.Data.Context.BaseContext context) => _context = context;
        public void Dispose() => _context.Dispose();
        public virtual async Task<IList<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] pPropriedades)
        {
            var dbQuery = _context.Set<TEntity>().AsNoTracking();

            foreach (Expression<Func<TEntity, object>> navigationProperty in pPropriedades)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            var lista = await dbQuery
                        .Where(where)
                        .ToListAsync<TEntity>();

            return lista;
        }
        public virtual Task<List<TEntity>> ListarTodos(params Expression<Func<TEntity, object>>[] pPropriedades)
        {
            IQueryable<TEntity> dbQuery = _context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> propriedade in pPropriedades)
                dbQuery = dbQuery.Include<TEntity, object>(propriedade);

            var lista = dbQuery
                     .AsNoTracking()
                     .ToListAsync<TEntity>();

            return lista;
        }

        public virtual async Task<bool> Adiciona(TEntity modelo)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    var ret = await _context.SaveChangesAsync();

                    trans.Commit();
                    return ret > 0;
                }
                catch (DbUpdateException dEx)
                {
                    trans.Rollback();
                    throw new Exception(dEx.Message);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual async Task<bool> Atualiza(TEntity modelo)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    var ret = await _context.SaveChangesAsync() > 0;

                    trans.Commit();
                    return ret;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual async Task<bool> Exclui(TEntity modelo)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    var ret = await _context.SaveChangesAsync() > 0;

                    trans.Commit();

                    return ret;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}
