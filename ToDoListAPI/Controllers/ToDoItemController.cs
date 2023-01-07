using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Data.ToDoItemRepo;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemRepo _toDoItemRepo;

        public ToDoItemController(IToDoItemRepo toDoItemRepo)
        {
            _toDoItemRepo = toDoItemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoItems()
        {
            var items = await _toDoItemRepo.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoItemModel(int id)
        {
            var toDoItemModel = await _toDoItemRepo.GetItemById(id);

            if (toDoItemModel == null)
            {
                return NotFound();
            }

            return Ok(toDoItemModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItemModel(int id, ToDoItemModel toDoItemModel)
        {
            if (id != toDoItemModel.ItemId)
            {
                return BadRequest();
            }

            try
            {
                await _toDoItemRepo.UpdateItem(toDoItemModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemModel>> PostToDoItemModel(ToDoItemModel toDoItemModel)
        {
            await _toDoItemRepo.CreateItem(toDoItemModel);

            return CreatedAtAction("GetToDoItemModel", new { id = toDoItemModel.ItemId }, toDoItemModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItemModel(int id)
        {
            var toDoItemModel = await _toDoItemRepo.GetItemById(id);
            if (toDoItemModel == null)
            {
                return NotFound();
            }

            await _toDoItemRepo.DeleteItem(toDoItemModel);

            return NoContent();
        }

        private bool ToDoItemModelExists(int id)
        {
            return _toDoItemRepo.ItemExists(id);
        }
    }
}
