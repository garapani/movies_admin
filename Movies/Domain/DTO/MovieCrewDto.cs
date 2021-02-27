using Domain.Entity;

namespace Domain.Dto
{
    public class MovieCrewDto
    {
        public int MovieId { get; set; }

        public MovieDto Movie { get; set; }

        public int CrewId { get; set; }

        public CrewDto Crew { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }

        public string Job { get; set; }

        public static MovieCrewDto FromModel(MovieCrew model)
        {
            return new MovieCrewDto()
            {
                MovieId = model.MovieId,
                Movie = MovieDto.FromModel(model.Movie),
                CrewId = model.CrewId,
                Crew = CrewDto.FromModel(model.Crew)
            };
        }

        public MovieCrew ToModel()
        {
            return new MovieCrew()
            {
                MovieId = MovieId,
                Movie = Movie.ToModel(),
                CrewId = CrewId,
                Crew = Crew.ToModel()
            };
        }
    }
}