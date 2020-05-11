using System;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
