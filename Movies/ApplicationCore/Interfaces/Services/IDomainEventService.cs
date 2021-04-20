using System;
using System.Threading.Tasks;
using Domain.Common;

namespace ApplicationCore.Interfaces.Services
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
