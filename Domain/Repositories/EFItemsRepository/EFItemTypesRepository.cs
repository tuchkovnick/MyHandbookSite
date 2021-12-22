using MyHandbookSite.Domain.Entities;
using MyHandbookSite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Domain.Repositories.EFItemsRepository
{
    public class EFItemTypesRepository : IItemTypesRepository
    {
        private readonly AppDbContext _context;

        public EFItemTypesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ItemType type)
        {
            _context.ItemTypes.Add(type);
            _context.SaveChanges();
        }

        public ItemType FindFirst(Guid id)
        {
            return _context.ItemTypes.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<ItemType> GetAll()
        {
            return _context.ItemTypes;
        }

        public void Remove(Guid id)
        {
            _context.Remove(new ItemType { Id = id});
            _context.SaveChanges();
        }
    }
}
