using System;
using ApplicationCore.Interfaces.Services;

namespace Persistence.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
