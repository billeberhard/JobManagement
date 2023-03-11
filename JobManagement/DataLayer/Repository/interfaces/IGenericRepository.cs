using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public interface IGenericRepository<T>
    {
        int Count();
        ICollection<T> GetAll();
        void Clear();
        bool Add(T item);
        bool Contains(T item);
        bool Remove(T item);
        bool Update(T item);
    }
}
