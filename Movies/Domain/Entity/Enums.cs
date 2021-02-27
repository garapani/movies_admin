using System.ComponentModel;

namespace Domain.Entity
{
    public enum EMovieGenre : byte
    {
        [Description("Action")]
        Action = 0,

        [Description("Adventure")]
        Adventure = 1,

        [Description("Comedy")]
        Comedy = 2,

        [Description("Crime")]
        Crime = 3,

        [Description("Thriller")]
        Thriller = 4,

        [Description("Drama")]
        Drama = 5,

        [Description("Romance")]
        Romance = 6,

        [Description("Suspense")]
        Suspense = 7,

        [Description("Horror")]
        Horror = 8,

        [Description("Cartoon")]
        Cartoon = 9,

        [Description("Animation")]
        Animation = 10
    }


    public enum ELanguage : byte
    {
        [Description("Telugu")]
        Telugu = 0,

        [Description("English")]
        English = 1,

        [Description("Hindi")]
        Hindi = 2,

        [Description("Tamil")]
        Tamil = 3,

        [Description("Kannada")]
        Kannada = 4,

        [Description("Malayalam")]
        Malayalam = 5,

        [Description("Marathi")]
        Marathi = 6,

        [Description("Bengaali")]
        Bengaali = 7
    }

    public enum EGender : byte
    {
        [Description("Male")]
        Male = 0,

        [Description("Female")]
        Female = 1
    }

    public enum EPersonType : byte
    {
        [Description("Cast")]
        Cast = 0,
        [Description("Crew")]
        Crew = 1
    }
}
