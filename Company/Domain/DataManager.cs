using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Domain.Repositories.Abstract;

namespace Company.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public  IServiceItemsRepository ServiceItems { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
        }
    }
}
