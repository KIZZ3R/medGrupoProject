using System.ComponentModel.DataAnnotations;

namespace InterviewProject.Service.ViewModel
{
    public class ViewModelContact 
    {
        public Guid Id { get; set; }
        public string? ContactName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        public bool Active { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate.Date > DateTime.Today.AddYears(-age))
                    age--;

                return age;
            }
        }
        public string ErrorMessage { get; set; }
        public bool Valid { get; set; } = true;
    }
}

