namespace LibraryManagement.Models.CreateDtos
{
    public class AuthorCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }
}
