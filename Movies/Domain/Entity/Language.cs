using Domain.Common;
using System;
namespace Domain.Entity
{
    public class Language : BaseEntity, IAggregateRoot
    {
        public Language()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
