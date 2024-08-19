namespace LibraryManagement.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
