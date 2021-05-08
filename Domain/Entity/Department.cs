using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entity
{
    public class Department : ValueObject<Department>
    {
        private Department(){ }

        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static Department Direction => new Department( "Direction");
        public static Department Music => new Department( "Music");
        public static Department BackgroundMusic => new Department("BackgroundMusic");
        public static Department Photography => new Department( "Photography");
        public static Department Editing => new Department("Editing");

        public static IEnumerable<Department> SupportedDepartments()
        {
                yield return Direction;
                yield return Music;
                yield return BackgroundMusic;
                yield return Photography;
                yield return Editing;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
