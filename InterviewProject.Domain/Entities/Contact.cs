namespace InterviewProject.Domain.Entities
{
    public class Contact : ContactBase
    {
        public bool Active { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ContactName { get; set; }

        public string? Gender { get; set; }

    }
}
