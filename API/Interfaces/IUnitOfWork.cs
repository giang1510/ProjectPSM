using System;

namespace API.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    public IProductRepository ProductRepository { get; }

    /// <summary>
    /// Save changes to the database
    /// </summary>
    /// <returns></returns>
    Task<bool> Complete();

    /// <summary>
    /// Check if there are any changes to the database
    /// </summary>
    /// <returns></returns>
    bool HasChanges();
}
