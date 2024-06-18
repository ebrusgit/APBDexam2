using System.ComponentModel.DataAnnotations;

namespace SailboatsApp.Models.Requests
{
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public int IdPublishingHouse { get; set; }
        
        public string PublishingHouseName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        
        [Required]
        public List<int> AuthorIds { get; set; }
        
        [Required]
        public List<int> GenreIds { get; set; }
    }
}