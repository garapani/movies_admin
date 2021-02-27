using Domain.Common;
using System;
namespace Domain.Entity
{
    public class Gender : BaseEntity
    {
        public Gender()
        {
        }

        public string Name { get; set; }
    }
}
