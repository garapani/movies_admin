using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Common.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}