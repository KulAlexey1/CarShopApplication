using System;
using System.Collections.Generic;

namespace DataServices.EFService
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetByKey(int key);

        void Add(T item);
        void Update(T item);
        void Remove(T item);

        void Save();
    }
}
