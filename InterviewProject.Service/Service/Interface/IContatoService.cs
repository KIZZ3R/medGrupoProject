using InterviewProject.Service.ViewModel;

namespace InterviewProject.Service.Service.Interface
{
    public interface IContactService
    {
        Task<IEnumerable<ViewModelContact>> GetAll();
        Task<ViewModelContact> Delete(Guid id);
        Task<ViewModelContact> Change(ViewModelContact obj);
        Task<ViewModelContact> Desactive(Guid id);
        Task<ViewModelContact> ReturnById(Guid id);
        Task<ViewModelContact> Add(ViewModelContact obj);

    }
}
