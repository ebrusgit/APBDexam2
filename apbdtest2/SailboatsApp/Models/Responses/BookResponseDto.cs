namespace SailboatsApp.Models.Responses
{
    public class BookResponseDto
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public PublishingHouseDto PublishingHouse { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }

    public class PublishingHouseDto
    {
        public int IdPublishingHouse { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

    public class AuthorDto
    {
        public int IdAuthor { get; set; }
        public string Name { get; set; }
    }

    public class GenreDto
    {
        public int IdGenre { get; set; }
        public string Name { get; set; }
    }
}