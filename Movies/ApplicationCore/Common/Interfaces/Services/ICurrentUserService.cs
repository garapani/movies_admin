using System;
namespace ApplicationCore.Common.Interfaces.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
