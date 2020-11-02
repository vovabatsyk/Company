using dotNetCompany.Domain.Repositories.Abstract;

namespace dotNetCompany.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFieldsRepository { get; set; }
        public IServiceItemsRepository ServiceItemsRepository { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
        {
            TextFieldsRepository = textFieldsRepository;
            ServiceItemsRepository = serviceItemsRepository;
        }
    }
}
