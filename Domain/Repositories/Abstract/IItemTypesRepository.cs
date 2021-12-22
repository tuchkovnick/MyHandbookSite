using MyHandbookSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Domain.Repositories.Abstract
{
    public interface IItemTypesRepository
    {        
        IQueryable<ItemType> GetAll();
        void Add(ItemType type);
        ItemType FindFirst(Guid id);
        void Remove(Guid id);
    }
}
