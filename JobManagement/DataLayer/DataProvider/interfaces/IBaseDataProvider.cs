﻿using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface IBaseDataProvider<T>
    {
        bool Add(T item);
        bool Contains(T item);
        bool Remove(T item);
        bool Update(T item);
    }
}
