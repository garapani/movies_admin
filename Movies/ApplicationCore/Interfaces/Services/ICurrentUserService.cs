using System;
namespace ApplicationCore.Interfaces.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
