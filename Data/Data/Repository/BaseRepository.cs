using Data.IRepository;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repository
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            try
            {
                using (var context = new LexmarkCatalogEntities())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se realizó la acción: {ex.Message}");
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                using (var context = new LexmarkCatalogEntities())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se realizó la acción: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new LexmarkCatalogEntities())
                {
                    var entity = context.Set<TEntity>().Find(id);
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se realizó la acción: {ex.Message}");
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using (var context = new LexmarkCatalogEntities())
                {
                    return context.Set<TEntity>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se realizó la acción: {ex.Message}");
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                using (var context = new LexmarkCatalogEntities())
                {
                    return context.Set<TEntity>().Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se realizó la acción: {ex.Message}");
            }
        }

        public void Dispose()
        {
            //Acción que se ejecuta por defecto adicional
            throw new NotImplementedException();
        }

    }
}
