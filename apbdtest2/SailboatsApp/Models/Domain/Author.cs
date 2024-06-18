namespace SailboatsApp.Models.Domain
{
    public class Author
    {
        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}