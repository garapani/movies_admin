using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entity
{
    public class Gender : ValueObject<Gender>
    {
        public string Name { get; }
        private Gender() { }

        public Gender(string name)
        {
            Name = name;
        }

        public static Gender Male => new Gender("Male");
        public static Gender Female => new Gender( "Female");

        public static IEnumerable<Gender> SupportedGender
        {
            get
            {
                yield return Male;
                yield return Female;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
