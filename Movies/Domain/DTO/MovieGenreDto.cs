using Domain.Entity;

namespace Domain.Dto
{
    public class MovieGenreDto
    {
        public int MovieId { get; set; }

        public MovieDetailDto Movie { get; set; }

        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public static MovieGenreDto FromModel(MovieGenre model)
        {
            return new MovieGenreDto()
            {
                MovieId = model.MovieId, 
                Movie = MovieDetailDto.FromModel(model.Movie), 
                GenreId = model.GenreId, 
                Genre = GenreDto.FromModel(model.Genre), 
            }; 
        }

        public MovieGenre ToModel()
        {
            return new MovieGenre()
            {
                MovieId = MovieId, 
                Movie = Movie.ToModel(), 
                GenreId = GenreId, 
                Genre = Genre.ToModel(), 
            }; 
        }
    }
}