using System.Collections.Generic;
using System.Data.Entity;
using Data;

namespace DataServices.EFService
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly CarShopDBContext carShopDb;

        public AddressRepository()
        {
            carShopDb = new CarShopDBContext();
        }

        public IEnumerable<Address> GetAll()
        {
            return carShopDb.Addresses;
        }

        public Address GetByKey(int key)
        {
            return carShopDb.Addresses.Find(key);
        }

        public void Add(Address item)
        {
            carShopDb.Addresses.Add(item);
        }

        public void Remove(Address item)
        {
            carShopDb.Addresses.Remove(item);
        }

        public void Update(Address item)
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
