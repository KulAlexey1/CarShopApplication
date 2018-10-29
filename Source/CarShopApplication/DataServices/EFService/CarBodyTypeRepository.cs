using System.Collections.Generic;
using System.Data.Entity;
using Data;

namespace DataServices.EFService
{
    public class CarBodyTypeRepository : IRepository<CarBodyType>
    {
        private readonly CarShopDBContext carShopDb;

        public CarBodyTypeRepository()
        {
            carShopDb = new CarShopDBContext();
        }

        public IEnumerable<CarBodyType> GetAll()
        {
            return carShopDb.CarBodyTypes;
        }

        public CarBodyType GetByKey(int key)
        {
            return carShopDb.CarBodyTypes.Find(key);
        }

        public void Add(CarBodyType item)
        {
            carShopDb.CarBodyTypes.Add(item);
        }

        public void Remove(CarBodyType item)
        {
            carShopDb.CarBodyTypes.Remove(item);
        }

        public void Update(CarBodyType item)
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
