namespace SailboatsApp.Models.Domain
{
    public class Book
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int IdPublishingHouse { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}