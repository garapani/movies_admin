using Domain.Entity;

namespace Domain.Dto
{
    public class MovieCastDto
    {
        public int MovieId { get; set; }

        public MovieDto Movie { get; set; }

        public GenderDto Gender { get; set; }

        public int ActorId { get; set; }

        public ActorDto Actor { get; set; }

        public string CharacterName { get; set; }

        public int CastOrder { get; set; }

        public static MovieCastDto FromModel(MovieCast model)
        {
            return new MovieCastDto()
            {
                MovieId = model.MovieId, 
                Movie = MovieDto.FromModel(model.Movie),
                ActorId = model.ActorId, 
                Actor = ActorDto.FromModel(model.Actor), 
                CharacterName = model.CharacterName, 
                CastOrder = model.CastOrder, 
            }; 
        }

        public MovieCast ToModel()
        {
            return new MovieCast()
            {
                MovieId = MovieId, 
                Movie = Movie.ToModel(),
                ActorId = ActorId, 
                Actor = Actor.ToModel(), 
                CharacterName = CharacterName, 
                CastOrder = CastOrder, 
            }; 
        }
    }
}