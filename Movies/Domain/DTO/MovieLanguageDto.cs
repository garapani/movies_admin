using Domain.Entity;

namespace Domain.Dto
{
    public class MovieLanguageDto
    {
        public int MovieLanguageId { get; set; }

        public int MovieId { get; set; }

        public MovieDetailDto Movie { get; set; }

        public int LanguageId { get; set; }

        public LanguageDto Language { get; set; }

        public static MovieLanguageDto FromModel(MovieLanguage model)
        {
            return new MovieLanguageDto()
            {
                MovieId = model.MovieId, 
                Movie = MovieDetailDto.FromModel(model.Movie), 
                LanguageId = model.LanguageId, 
                Language = LanguageDto.FromModel(model.Language), 
            }; 
        }

        public MovieLanguage ToModel()
        {
            return new MovieLanguage()
            {
                MovieId = MovieId, 
                Movie = Movie.ToModel(), 
                LanguageId = LanguageId, 
                Language = Language.ToModel(), 
            }; 
        }
    }
}