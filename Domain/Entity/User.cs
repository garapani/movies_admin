using Domain.Common;
namespace Domain.Entity
{
    public class User : AuditableEntity, IAggregateRoot
    {
        public User()
        {
        }
        public virtual int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
