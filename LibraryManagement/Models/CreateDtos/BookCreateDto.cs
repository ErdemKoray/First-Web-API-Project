namespace LibraryManagement.Models.CreateDtos
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
    }
}
