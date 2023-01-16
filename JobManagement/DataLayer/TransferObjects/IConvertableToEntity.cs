namespace DataLayer.TransferObjects
{
    internal interface IConvertableToEntity<TEntity>
    {
        TEntity ConvertToEntity();
    }
}