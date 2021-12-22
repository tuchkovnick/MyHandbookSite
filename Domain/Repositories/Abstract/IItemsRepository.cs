using MyHandbookSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Domain.Repositories.Abstract
{
    public interface IItemsRepository
    {
        IQueryable<Item> FindByParameter(string parameter);
        IQueryable<Item> FindByType(Guid type);
        Item FindFirst(Guid id);
        void Add(Item newItem);
        void Remove(Guid id);
        void RemoveByType(Guid typeId);
    }
}
