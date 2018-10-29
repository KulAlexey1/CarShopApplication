using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DataServices.EFService
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private readonly CarShopDBContext carShopDb;

        public ManufacturerRepository()
        {
            carShopDb = new CarShopDBContext();
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return carShopDb.Manufacturers;
        }

        public Manufacturer GetByKey(int key)
        {
            return carShopDb.Manufacturers.Find(key);
        }

        public void Add(Manufacturer item)
        {
            carShopDb.Manufacturers.Add(item);
        }

        public void Remove(Manufacturer item)
        {
            carShopDb.Manufacturers.Remove(item);
        }

        public void Update(Manufacturer item)
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
