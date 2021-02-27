namespace Domain.Entity
{
    public class Country : Common.BaseEntity
    {
        public Country()
        {
        }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
