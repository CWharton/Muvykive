using System.Collections.Generic;

namespace Muvykive.Model
{
    public interface IRepository<T> 
    {
        void Save(T entity);
        void Update(T entity);
        void Create(T entity);
        void Delete(T entity);

        T FindBy(int id);
        IList<T> FindAll();
    }
}