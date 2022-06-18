using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using Northwind.Entity.IBase;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Bll
{
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        //UnitOfWork
        //IServiceProvider
        //GenericRepository
        //Constructor

        #region Variables
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        #endregion

        #region Constructor
        public GenericManager(IServiceProvider service)
        {
            this.service = service;
            unitOfWork = service.GetService<IUnitOfWork>();
            repository = unitOfWork.GetRepository<T>();
        }
        #endregion

        #region Methods
        public IResponce<TDto> Add(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto verisi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                // var resolvesResult = String.Join(',', model.GetType().GetProperties().Select(x => $" - {x.Name} : {x.GetValue(model) ?? ""} - "));
                var result = repository.Add(model);

                if (saveChanges)
                {
                    Save(); //kaydetme işlemi olduğundan transaction'ı commit'liyoruz.
                }
                //dönüş tipini ayarlıyoruz
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<IResponce<TDto>> AddAsync(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto verisi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                // var resolvesResult = String.Join(',', model.GetType().GetProperties().Select(x => $" - {x.Name} : {x.GetValue(model) ?? ""} - "));
                var result = await repository.AddAsync(model);

                if (saveChanges)
                {
                    Save(); //kaydetme işlemi olduğundan transaction'ı commit'liyoruz.
                }
                //dönüş tipini ayarlıyoruz
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponce<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);
                if (saveChanges)
                {
                    Save();
                }
                return new Responce<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Responce<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}"
                };
            }
        }

        public Task<IResponce<TDto>> DeleteByIdAsync(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponce<TDto> Find(int id)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id));
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponce<List<TDto>> GetAll()
        {
            try
            {
                var list = repository.GetAll();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new Responce<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Responce<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponce<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                var list = repository.GetAll(expression);
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new Responce<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Responce<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponce<IQueryable<TDto>> GetQueryable()
        {
            try
            {
                var list = repository.GetQueryable();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x));
                return new Responce<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Responce<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        public IResponce<TDto> Update(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto verisi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                // var resolvesResult = String.Join(',', model.GetType().GetProperties().Select(x => $" - {x.Name} : {x.GetValue(model) ?? ""} - "));
                var result = repository.Update(model);

                if (saveChanges)
                {
                    Save(); //kaydetme işlemi olduğundan transaction'ı commit'liyoruz.
                }
                //dönüş tipini ayarlıyoruz
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Updated",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Responce<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<IResponce<TDto>> UpdateAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}