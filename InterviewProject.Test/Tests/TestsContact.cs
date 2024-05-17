using InterviewProject.Service.Service.Interface;
using InterviewProject.Service.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewProject.Tests.ContatoTest
{
    public class TestsContact : BaseTest
    {
        public IContactService _serviceContact;

        public TestsContact()
        {
            _serviceContact = _serviceProvider.GetRequiredService<IContactService>();
        }

        [Test]
        public async Task Success_Add()
        {
            var createContact = new ViewModelContact
            {
                BirthDate = DateTime.Parse("08-19-1994"),
                ContactName = "Carlos ALberto",
                Active = true,
                Gender = "F"
            };

            var result = await _serviceContact.Add(createContact);
            var contactExist = await _context.Contact.AnyAsync(p => p.ContactName == createContact.ContactName);

            Assert.That(result.Valid, Is.True);
        }

        [Test]
        public async Task AddBelowEighteen_Error()
        {
            var createContact = new ViewModelContact() {    BirthDate = DateTime.Parse("10-6-2020"), ContactName = "Vitor Rafael", Active = true, Gender = "F"   };

            var actionResult = await _serviceContact.Add(createContact);

            Assert.That(actionResult.Valid, Is.False);
        }

        [Test]
        public async Task AddBirthDate_higherThanToday_Fail()
        {
            var msg = "Houve um problema ao incluir o contato A data de nascimento é maior que a atual, por favor insira uma data válida";
            var createContact = new ViewModelContact() { BirthDate = DateTime.Now.AddDays(1), ContactName = "Vitor Rafael", Active = true, Gender = "M" };

            var actionResult = await _serviceContact.Add(createContact);
	        
            Assert.That(actionResult.Valid == false && actionResult.ErrorMessage == msg);

        }
    }
}
