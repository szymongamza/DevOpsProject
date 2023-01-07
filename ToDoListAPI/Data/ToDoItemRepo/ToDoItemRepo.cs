using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data.ToDoItemRepo
{
    public class ToDoItemRepo:IToDoItemRepo
    {
        private readonly AppDbContext _context;

        public ToDoItemRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ToDoItemModel>> GetAllItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItemModel?> GetItemById(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task UpdateItem(ToDoItemModel item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task CreateItem(ToDoItemModel item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(ToDoItemModel item)
        {
            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public bool ItemExists(int id)
        {
            return _context.ToDoItems.Any(e => e.ItemId == id);
        }
    }
}
