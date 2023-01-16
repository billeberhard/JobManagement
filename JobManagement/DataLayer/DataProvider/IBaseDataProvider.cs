namespace DataLayer.DataProvider
{
    internal interface IBaseDataProvider<T>
    {
        void Add(T item);
        bool Contains(T item);
        bool Remove(T item);
    }
}
