using System.Collections.Generic;
using System.Linq;
using Domain.Entity;

namespace ApplicationCore.ExtensionMethods
{
    public static class UserExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}
