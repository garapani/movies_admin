using Domain.Entity;

namespace Domain.Dto
{
    public class GenreDto
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public static GenreDto FromModel(Genre model)
        {
            return new GenreDto()
            {
                GenreId = model.Id, 
                Name = model.Name, 
            }; 
        }

        public Genre ToModel()
        {
            return new Genre()
            {
                //Id = GenreId, 
                Name = Name, 
            }; 
        }
    }
}