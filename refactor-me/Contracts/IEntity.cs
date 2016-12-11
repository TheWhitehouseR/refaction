using System;

namespace ProductsApi.Contracts
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}