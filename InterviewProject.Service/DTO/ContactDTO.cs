using System.ComponentModel.DataAnnotations;

namespace InterviewProject.Service.DTO
{
    public class ContactDTO
    {
        public DateTime BirthDate { get; set; }
        public string? ContactName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public bool Active { get; set; }
        public string? Gender { get; set; }
    }
}
