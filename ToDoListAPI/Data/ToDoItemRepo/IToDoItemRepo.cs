using ToDoListAPI.Models;

namespace ToDoListAPI.Data.ToDoItemRepo
{
    public interface IToDoItemRepo
    {
        Task<IEnumerable<ToDoItemModel>> GetAllItems();
        Task<ToDoItemModel?> GetItemById(int id);
        Task UpdateItem(ToDoItemModel item);
        Task CreateItem(ToDoItemModel item);
        Task DeleteItem(ToDoItemModel item);
        bool ItemExists(int id);
    }
}
