using System.Collections.Generic;
using System.Data.Entity;
using Data;

namespace DataServices.EFService
{
    public class CarRepository : IRepository<Car>
    {
        private readonly CarShopDBContext carShopDb;

        public CarRepository()
        {
            carShopDb = new CarShopDBContext();
        }

        public IEnumerable<Car> GetAll()
        {
            return carShopDb.Cars;
        }

        public Car GetByKey(int key)
        {
            return carShopDb.Cars.Find(key);
        }

        public void Add(Car item)
        {
            carShopDb.Cars.Add(item);
        }

        public void Remove(Car item)
        {
            carShopDb.Cars.Remove(item);
        }

        public void Update(Car item)
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
