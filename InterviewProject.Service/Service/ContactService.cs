using InterviewProject.Data.Repository.Interface;
using InterviewProject.Domain.Entities;
using InterviewProject.Service.Service.Interface;
using InterviewProject.Service.Validation;
using InterviewProject.Service.ViewModel;
using AutoMapper;

namespace InterviewProject.Service.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactsRepository _repositoryContact;
        private readonly IMapper _mapper;

        public ContactService(IContactsRepository contactRepo, IMapper mapper)
        {
            _repositoryContact = contactRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViewModelContact>> GetAll()
        {
            var contactList = _repositoryContact.GetAll();
            var returnList = _mapper.Map<List<ViewModelContact>>(contactList);

            return returnList.Where(p => p.Active == true);
        }

        public async Task<ViewModelContact> Delete(Guid id)
        {
            var objReturn = new ViewModelContact();

            var deletionObject = _repositoryContact.GetByID(id);

            if (deletionObject == null)
            {
                objReturn.Valid = false;
                objReturn.ErrorMessage = "Não foi possível encontrar o Id";
            }
            else
            {
                try
                {
                    _repositoryContact.Delete(deletionObject);
                    objReturn.Valid = true;
                }
                catch (Exception ex)
                {
                    objReturn.Valid = false;
                    objReturn.ErrorMessage = "Tivemos um erro ao deletar" + ex.Message;
                }

            }

            return objReturn;

        }

        public async Task<ViewModelContact> Add(ViewModelContact obj)
        {
            var validationObject = ContactValidation.ValidarDados(obj);
            
            if (validationObject.Valid) 
            {
                try
                {
                    var inclusionObject = _mapper.Map<Contact>(obj);
                    _repositoryContact.Save(inclusionObject);
                    obj.Id = inclusionObject.Id;
                    obj.Valid = true;
                }
                catch (Exception ex)
                {

                    obj.Valid = false;
                    obj.ErrorMessage = "Tivemos um problema ao tentar incluir o contato" + ex.Message;
                }
            }
            else 
            {
                obj.Valid = false;
                obj.ErrorMessage = "Houve um problema ao incluir o contato " + validationObject.ErrorMessage;
            }
            
            return obj;

        }

        public async Task<ViewModelContact> Change(ViewModelContact obj)
        {
            var validationObject = ContactValidation.ValidarDados(obj);
            if (validationObject.Valid)
            {
                var modificationObject = _repositoryContact.GetByID(obj.Id);

                modificationObject.ContactName = obj.ContactName;
                modificationObject.BirthDate = obj.BirthDate;
                modificationObject.Gender = obj.Gender;
                modificationObject.Active = obj.Active;

                _repositoryContact.Change(modificationObject);
                obj.Valid = true;

            }
            else
            {
                obj.Valid = false;
                obj.ErrorMessage = "Houve um problema ao alterar o contato" + validationObject.ErrorMessage;
            }

            return obj;

        }

        public async Task<ViewModelContact> ReturnById(Guid id)
        {
            var returnObj = new ViewModelContact();
            var contactObject = _repositoryContact.GetByID(id);
            
            if (contactObject.Active)
            {
                returnObj = _mapper.Map<ViewModelContact>(contactObject);
            }
            else
            {
                returnObj.Valid = false;
                returnObj.ErrorMessage = "O Contact solicitado está Inativo";
            }
            
            return returnObj;
        }

        public async Task<ViewModelContact> Desactive(Guid id)
        {
            var objReturn = new ViewModelContact();

            try
            {
                var objContato = _repositoryContact.GetByID(id);
                objContato.Active = false;

                _repositoryContact.Change(objContato);
                
                objReturn = _mapper.Map<ViewModelContact>(objContato);
                objReturn.Valid = true;
            }
            catch (Exception ex)
            {
                objReturn.Valid = false;
                objReturn.ErrorMessage = "Erro ao desativar Contact" + ex.Message;
            }
            
            return objReturn;
        }
    }
}
