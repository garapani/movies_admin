using System;
using System.Threading.Tasks;
using Domain.Common;

namespace ApplicationCore.Common.Interfaces.Services
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
