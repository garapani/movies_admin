namespace Domain.Entity
{
    public class MovieLanguage
    {
        public MovieLanguage()
        {
        }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
