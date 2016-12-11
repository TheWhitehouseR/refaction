using Moq;
using ProductsApi.Contracts;
using ProductsApi.Data;
using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Tests.MockData
{
    public class MockRepository : IRepository
    {
        private IRepository _fakeRepository;

        public MockRepository()
        {
            var data = new MocksProducts().Items.AsQueryable();

            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var fakeDb = new Mock<ProductDbContext>();
            fakeDb.Setup(x => x.Products).Returns(mockProductSet.Object);
            fakeDb.Setup(x => x.Set<Product>()).Returns(mockProductSet.Object);

            _fakeRepository = new GeneralRepository(fakeDb.Object);
        }

        public void Dispose()
        {
            _fakeRepository.Dispose();
        }

        public void SaveChanges()
        {
            _fakeRepository.SaveChanges();
        }

        void IRepository.Delete<T>(Guid guid)
        {
            _fakeRepository.Delete<T>(guid);
        }

        void IRepository.Insert<T>(IEnumerable<T> items)
        {
            _fakeRepository.Insert<T>(items);
        }

        void IRepository.Insert<T>(T item)
        {
            _fakeRepository.Insert<T>(item);
        }

        IQueryable<T> IRepository.Query<T>()
        {
            return _fakeRepository.Query<T>();
        }

        void IRepository.Update<T>(T item)
        {
            _fakeRepository.Update<T>(item);
        }
    }
}
