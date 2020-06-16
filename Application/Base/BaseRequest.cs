namespace Application.Base
{
    public abstract class BaseRequest
    {
        
    }

    public abstract class Request<T> : BaseRequest, IRequest<T> where T  : Domain.Base.BaseEntity
    {
        public abstract T ToEntity();
    }
}