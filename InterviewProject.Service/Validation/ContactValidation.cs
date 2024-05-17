using InterviewProject.Service.ViewModel;

namespace InterviewProject.Service.Validation
{
    public class ContactValidation
    {
        public static ViewModelContact ValidarDados(ViewModelContact contactObj)
        {
            ViewModelContact validation = new ViewModelContact() { Valid = true };

            if (contactObj.BirthDate > DateTime.Now)
                validation = new ViewModelContact() { 
                    Valid = false, ErrorMessage = "A data de nascimento é maior que a atual, por favor insira uma data válida" 
                };
            else
            {
                if (contactObj.Age < 18)
                    validation = new ViewModelContact() {
                        Valid = false, ErrorMessage = "Ele deve ser maior de idade" 
                    };
            }

            return validation;
        }
    }
}
