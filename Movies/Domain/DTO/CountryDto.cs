using Domain.Entity;

namespace Domain.Dto
{
    public class CountryDto
    {
        public int CountryId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public static CountryDto FromModel(Country model)
        {
            return new CountryDto()
            {
                CountryId = model.Id, 
                Code = model.Code, 
                Name = model.Name, 
            }; 
        }

        public Country ToModel()
        {
            return new Country()
            {
                //Id = CountryId, 
                Code = Code, 
                Name = Name, 
            }; 
        }
    }
}