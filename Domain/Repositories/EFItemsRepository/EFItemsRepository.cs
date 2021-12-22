using Microsoft.EntityFrameworkCore;
using MyHandbookSite.Domain.Entities;
using MyHandbookSite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Domain.Repositories.EFItemsRepository
{
    public class EFItemsRepository : IItemsRepository
    {
        private readonly AppDbContext _context;
        public EFItemsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Item newItem)
        {            
            var item =  _context.Items.AsNoTracking()
                        .FirstOrDefault(i=>i.Id == newItem.Id);
            if (item == default)
            {
                _context.Items.Add(newItem);
            }
            else
            {
                item = newItem;              
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var item = FindFirst(id);
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public IQueryable<Item> FindByType(Guid type)
        {
            return _context.Items.Where(i => i.TypeId == type);
        }

        public IQueryable<Item> FindByParameter(string parameter)
        {
            return _context.Items.Where(x => x.Title.Contains(parameter) || x.Description.Contains(parameter));
        }

        public Item FindFirst(Guid id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == id);
        }

        public void RemoveByType(Guid id)
        {
            var items = _context.Items.Where(i => i.TypeId == id);
            foreach(var item in items)
            {
                _context.Items.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}
