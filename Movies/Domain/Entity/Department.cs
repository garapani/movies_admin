using Domain.Common;
using System;
namespace Domain.Entity
{
    public class Department : BaseEntity
    {
        public Department()
        {
        }

        public string Name { get; set; }
    }
}
