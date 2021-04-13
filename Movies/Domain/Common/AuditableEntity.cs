﻿using System;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
