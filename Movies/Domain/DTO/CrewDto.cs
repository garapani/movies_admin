using Domain.Entity;

namespace Domain.Dto
{
    public class CrewDto
    {
        public CrewDto()
        {
        }

        public int CrewId { get; set; }

        public string Name { get; set; }

        public ImageDto Image { get; set; }

        public DepartmentDto Department { get; set; }

        public static CrewDto FromModel(Crew model)
        {
            return new CrewDto()
            {
                CrewId = model.Id,
                Name = model.Name,
                Image = ImageDto.FromModel(model.Image),
                Department = DepartmentDto.FromModel(model.Department)
            };
        }

        public Crew ToModel()
        {
            return new Crew
            {
                //Id = CrewId,
                Name = Name,
                Image = Image?.ToModel(),
                Department = Department?.ToModel()
            };
        }
    }
}
