namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
