using System;
using System.Linq;
using Company.Domain.Entities;
using Company.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Company.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository: IServiceItemsRepository
    {
        private readonly AppDbCondext context;

        public EFServiceItemsRepository(AppDbCondext context)
        {
            this.context = context;
        }
        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void DeleteServiceItem(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }
}