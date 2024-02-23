using UnityWithBackendWorkshop.Domain.Core;

namespace UnityWithBackendWorkshop.Application
{
    public interface IRepository<TAggregateRoot, TId>
        where TAggregateRoot : AggregateRoot<TId>
        where TId : ValueObject
    {
    }
}
