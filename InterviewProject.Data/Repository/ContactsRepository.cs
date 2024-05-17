using InterviewProject.Data.Data;
using InterviewProject.Data.Repository.Interface;
using InterviewProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject.Data.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly InterviewProjectDb _dbContext;

        public ContactsRepository(InterviewProjectDb dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Contact> GetAll()
        {
            var lista = _dbContext.Contact.OrderBy(p => p.ContactName).ToList();
            return lista;
        }

        public void Delete(Contact contact)
        {
            _dbContext.Contact.Remove(contact);
            _dbContext.SaveChanges();
        }
        

        public Contact GetByID(Guid idContact)
        {
            var contact = _dbContext.Contact.Where(p => p.Id == idContact).FirstOrDefault();
            return contact;
        }

        public void Save(Contact contact)
        {
            _dbContext.Add(contact);
            _dbContext.SaveChanges();
        }

        public void Change(Contact contact)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(contact).State = EntityState.Modified;
            _dbContext.Update(contact);
            _dbContext.SaveChanges();
        }
    }
}
