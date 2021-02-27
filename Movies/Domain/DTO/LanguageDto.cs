using Domain.Entity;

namespace Domain.Dto
{
    public class LanguageDto
    {
        public int LanguageId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public static LanguageDto FromModel(Language model)
        {
            if (model != null)
            {
                return new LanguageDto()
                {
                    LanguageId = model.Id,
                    Code = model.Code,
                    Name = model.Name,
                };
            }
            return null;
        }

        public Language ToModel()
        {
            return new Language()
            {
                //Id = LanguageId, 
                Code = Code, 
                Name = Name, 
            }; 
        }
    }
}