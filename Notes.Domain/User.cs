namespace Notes.Domain
{

    public class User
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<Note> Notes { get; set;}

    }
}
