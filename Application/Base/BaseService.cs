using Domain.Base;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Base
{
    public abstract class Service<T> : BaseService, IService<T> where T : BaseEntity
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IGenericRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        protected virtual void Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }
        protected virtual void Update(T entity)
        {
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        protected virtual List<T> Get(Expression<Func<T, bool>> expression = null, string include = "", uint page = 0, uint size = 10)
        {
            return _repository.FindBy(expression, includeProperties: include).Skip((int)(page * size)).Take((int)size).ToList();
        }

        protected virtual T Find(int id)
        {
            return _repository.Find(id);
        }
    }

    public abstract class BaseService
    {

    }
}
