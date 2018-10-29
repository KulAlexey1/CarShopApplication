using System.Collections.Generic;
using System.Data.Entity;
using Data;

namespace DataServices.EFService
{
    public class CarImageRepository : IRepository<CarImage>
    {
        private readonly CarShopDBContext carShopDb;

        public CarImageRepository()
        {
            carShopDb = new CarShopDBContext();
        }

        public IEnumerable<CarImage> GetAll()
        {
            return carShopDb.CarImages;
        }

        public CarImage GetByKey(int key)
        {
            return carShopDb.CarImages.Find(key);
        }

        public void Add(CarImage item)
        {
            carShopDb.CarImages.Add(item);
        }

        public void Remove(CarImage item)
        {
            carShopDb.CarImages.Remove(item);
        }

        public void Update(CarImage item)
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
