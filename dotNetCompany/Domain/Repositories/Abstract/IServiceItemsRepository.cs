using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetCompany.Entities;

namespace dotNetCompany.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}
