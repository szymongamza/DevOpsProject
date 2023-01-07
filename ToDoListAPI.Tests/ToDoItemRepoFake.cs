using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Data.ToDoItemRepo;
using ToDoListAPI.Models;


namespace ToDoListAPI.Tests
{
    public class ToDoItemRepoFake : IToDoItemRepo
    {
        private readonly List<ToDoItemModel> _toDoItem;

        public ToDoItemRepoFake()
        {
            _toDoItem = new List<ToDoItemModel>()
            {
                new ToDoItemModel() { ItemId = 1, ItemName = "DummyFirstName1", ItemStatus = false },
                new ToDoItemModel() { ItemId = 2, ItemName = "DummyFirstName2", ItemStatus = false },
                new ToDoItemModel() { ItemId = 3, ItemName = "DummyFirstName3", ItemStatus = false }
            };
        }
        public async Task<IEnumerable<ToDoItemModel>> GetAllItems()
        {
            return _toDoItem;
        }

        public async Task<ToDoItemModel?> GetItemById(int id)
        {
            var item = _toDoItem.Find(x => x.ItemId == id);
            return item;
        }

        public async Task UpdateItem(ToDoItemModel item)
        {
            var tempItem = _toDoItem.Find(x => x.ItemId == item.ItemId);
            tempItem = item;

        }

        public async Task CreateItem(ToDoItemModel item)
        {
            _toDoItem.Add(item);
        }

        public async Task DeleteItem(ToDoItemModel item)
        {
            _toDoItem.Remove(item);
        }

        public bool ItemExists(int id)
        {
            return _toDoItem.Any(x => x.ItemId == id);
        }
    }
}
