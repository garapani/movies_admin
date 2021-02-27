using Domain.Entity;

namespace Domain.Dto
{
    public class GenderDto
    {
        public int GenderId { get; set; }

        public string Name { get; set; }

        public static GenderDto FromModel(Gender model)
        {
            if (model != null)
            {
                return new GenderDto()
                {
                    GenderId = model.Id,
                    Name = model.Name,
                };
            }
            return null;
        }

        public Gender ToModel()
        {
            return new Gender()
            {
                //Id = GenderId, 
                Name = Name, 
            }; 
        }
    }
}