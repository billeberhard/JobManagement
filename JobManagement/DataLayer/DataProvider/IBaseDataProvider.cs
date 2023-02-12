namespace DataLayer.DataProvider
{
    internal interface IBaseDataProvider<T>
    {
        T Add(T item);
        bool Contains(T item);
        bool Remove(T item);
    }
}
