using Domain.Entity;

namespace Domain.Dto
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public static DepartmentDto FromModel(Department model)
        {
            return new DepartmentDto()
            {
                DepartmentId = model.Id, 
                Name = model.Name, 
            }; 
        }

        public Department ToModel()
        {
            return new Department()
            {
                //Id = DepartmentId, 
                Name = Name, 
            }; 
        }
    }
}