using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {
        //IEnumerable ile IQueryable farkı IQueryable veri tabanında işlemi yapar, IEnumerable ram'de işlemi yapar.
        //Listeleme
        IResponce<List<TDto>> GetAll();
        //Filtreli Listeleme
        IResponce<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        //Getirme
        IResponce<TDto> Find(int id);
        //Kaydetme
        IResponce<TDto> Add(TDto item, bool saveChanges = true);
        //Async Kaydetme
        Task<IResponce<TDto>> AddAsync(TDto item, bool saveChanges = true);
        //Güncelleme
        IResponce<TDto> Update(TDto item, bool saveChanges = true);
        //Async Güncelleme
        Task<IResponce<TDto>> UpdateAsync(TDto item, bool saveChanges = true);
        //Silme
        IResponce<bool> DeleteById(int id, bool saveChanges = true);
        //Async Silme
        Task<IResponce<TDto>> DeleteByIdAsync(int id, bool saveChanges = true);
        //Queryable Listeleme
        IResponce<IQueryable<TDto>> GetQueryable();
        void Save();
    }
}
