using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entity
{
    public class Language : ValueObject<Language>
    {
        private Language() { }
        public Language(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public Language( string name)
        {
            Name = name;
        }

        public string Code { get;}
        public string Name { get;}

        public static Language Telugu => new Language("TE", "Telugu");
        public static Language English => new Language("EN", "English");
        public static Language Hindi => new Language("HN", "Hindi");
        public static Language Tamil => new Language("TA", "Tamil");
        public static Language Kannada => new Language("KA", "Kannada");
        public static Language Malayalam => new Language("MA", "Malayalam");
        public static Language Marati => new Language("MA", "Marati");
        public static Language Bengali => new Language("BE", "Bengali");

        public static IEnumerable<Language> SupportedLanguages
        {
            get
            {
                yield return Telugu;
                yield return English;
                yield return Hindi;
                yield return Tamil;
                yield return Kannada;
                yield return Malayalam;
                yield return Marati;
                yield return Bengali;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
            yield return Name;

        }
    }
}
