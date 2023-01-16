namespace DataLayer.Repository
{
    public interface IRepository<T> : ICollection<T>
    {
        T Get(int id);
        List<T> GetAll();
    }
}
