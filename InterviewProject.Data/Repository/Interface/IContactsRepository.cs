using InterviewProject.Domain.Entities;

namespace InterviewProject.Data.Repository.Interface
{
    public interface IContactsRepository
    {
        Contact GetByID(Guid idContact);
        List<Contact> GetAll();
        void Save(Contact client);
        void Delete(Contact client);
        void Change(Contact contact);
    }
}
