using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entity
{
    public class Genre : ValueObject<Genre>
    {
        public string Name { get; }
        private Genre() { }

        public Genre(string name)
        {
            Name = name;
        }

        public static Genre Action => new Genre("Action");
        public static Genre Adventure => new Genre("Adventure");
        public static Genre Comedy => new Genre("Comedy");
        public static Genre Crime => new Genre("Crime");
        public static Genre Thriller => new Genre("Thriller");
        public static Genre Drama => new Genre("Drama");
        public static Genre Romance => new Genre("Romance");
        public static Genre Suspense => new Genre("Suspense");
        public static Genre Horror => new Genre("Horror");
        public static Genre Cartoon => new Genre("Cartoon");
        public static Genre Animation => new Genre("Animation");

        protected static IEnumerable<Genre> SupportedGenre
        {
            get {
                yield return Action;
                yield return Adventure;
                yield return Comedy;
                yield return Crime;
                yield return Thriller;
                yield return Drama;
                yield return Romance;
                yield return Suspense;
                yield return Horror;
                yield return Cartoon;
                yield return Animation;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
