using MyHandbookSite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Domain
{
    public class DataManager
    {
        public IItemsRepository Items { set; get; }
        public IItemTypesRepository ItemTypes { set; get; }

        public DataManager(IItemsRepository itemsRepository, IItemTypesRepository itemTypesRepository)
        {
            Items = itemsRepository;
            ItemTypes = itemTypesRepository;
        }

        
    }
}
