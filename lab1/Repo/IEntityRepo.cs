using lab1.Models;

namespace lab1.Repo
{
    
    public interface IEntityRepo<T>
    {
        List<T> GetAll();
        T Get(int id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(int id);
        int Save();
    }
}
