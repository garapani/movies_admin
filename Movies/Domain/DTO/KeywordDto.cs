using Domain.Entity;

namespace Domain.Dto
{
    public class KeywordDto
    {
        public int KeywordId { get; set; }

        public string Name { get; set; }

        public static KeywordDto FromModel(Keyword model)
        {
            return new KeywordDto()
            {
                KeywordId = model.Id, 
                Name = model.Name, 
            }; 
        }

        public Keyword ToModel()
        {
            return new Keyword()
            {
                //Id = KeywordId, 
                Name = Name, 
            }; 
        }
    }
}