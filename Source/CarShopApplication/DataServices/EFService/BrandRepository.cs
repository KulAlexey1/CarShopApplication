using System.Collections.Generic;
using System.Data.Entity;
using Data;

namespace DataServices.EFService
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly CarShopDBContext carShopDb;

        public BrandRepository()
        {
            carShopDb = new CarShopDBContext();
        }

        public IEnumerable<Brand> GetAll()
        {
            return carShopDb.Brands;
        }

        public Brand GetByKey(int key)
        {
            return carShopDb.Brands.Find(key);
        }

        public void Add(Brand item)
        {
            carShopDb.Brands.Add(item);
        }

        public void Remove(Brand item)
        {
            carShopDb.Brands.Remove(item);
        }        

        public void Update(Brand item)
        {
            carShopDb.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            carShopDb.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    carShopDb.Dispose();
                }
                // Dispose unmanaged state (unmanaged objects).
                // Override finalizer and change void Dispose() method too.
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
