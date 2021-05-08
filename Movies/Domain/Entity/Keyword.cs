using System.Collections.Generic;
using Domain.Common;
namespace Domain.Entity
{
    public class Keyword: ValueObject<Keyword>
    {
        public string Name { get; }

        private Keyword() { }
        public Keyword(string name)
        {
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
