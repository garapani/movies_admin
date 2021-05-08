using System.Collections.Generic;

namespace Domain.Entity
{
    public class Country : Common.ValueObject<Country>
    {
        private Country()
        {
        }

        public Country(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }
        public string Name { get; }

        public static Country India => new Country("IN", "India");

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        protected static IEnumerable<Country> SupportedCountries
        {
            get
            {
                yield return India;
            }
        }
    }
}
