namespace SailboatsApp.Models.Domain
{
    public class PublishingHouse
    {
        public int IdPublishingHouse { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}