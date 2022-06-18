using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Abstract
{
    public interface IGenericRepository<T> where T : IEntityBase
    {
        //IEnumerable ile IQueryable farkı IQueryable veri tabanında işlemi yapar, IEnumerable ram'de işlemi yapar.
        //Listeleme
        List<T> GetAll();
        //Filtreli Listeleme
        List<T> GetAll(Expression<Func<T, bool>> expression);
        //Getirme
        T Find(int id);
        //Kaydetme
        T Add(T item);
        //Async Kaydetme
        Task<T> AddAsync(T item);
        //Güncelleme
        T Update(T item);
        //Silme
        bool Delete(int id);
        bool Delete(T item);
        //Queryable Listeleme
        IQueryable<T> GetQueryable();
    }
}
