using System.Collections.Generic;

namespace Muvykive.Repository.Repositories
{
    /// <summary>
    /// Default Repository Actions
    /// </summary>
    /// <typeparam name="T">Domain Class</typeparam>
    public abstract class Repository<T>
    {
        public void Create(T entity)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Delete(T entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void Update(T entity)
        {
            SessionFactory.GetCurrentSession().Update(entity);
        }

        public T FindBy(int id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(id);
        }

        public IList<T> FindAll()
        {
            return SessionFactory.GetCurrentSession().CreateCriteria(typeof (T)).List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return SessionFactory.GetCurrentSession().CreateCriteria(typeof (T)).SetFetchSize(count).SetFirstResult(index).List<T>();
        }
    }
}