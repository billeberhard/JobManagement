namespace DataLayer.Repository
{
    public interface IGenericRepository<T>
    {
        int Count();
        ICollection<T> GetAll();
        void Clear();
        T Add(T item);
        bool Contains(T item);
        bool Remove(T item);
    }
}
