using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }

        //internal purpose
        [DataType(DataType.Date)]
        public DateTimeOffset CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
