using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDoListAPI.Controllers;
using ToDoListAPI.Models;
using Xunit;

namespace ToDoListAPI.Tests
{
    public class ToDoItemControllerTest
    {
        private readonly ToDoItemRepoFake _toDoItemRepo;
        private readonly ToDoItemController _controller;

        public ToDoItemControllerTest()
        {
            _toDoItemRepo = new ToDoItemRepoFake();
            _controller = new ToDoItemController(_toDoItemRepo);
        }
        [Fact]
        public async void GetToDoItemList_WhenCalled_ReturnsOkResult()
        {
            var okResult = await _controller.GetToDoItems();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetToDoItemList_WhenCalled_ReturnsAllBuildings()
        {
            var okResult = await _controller.GetToDoItems() as OkObjectResult;

            var buildings = Assert.IsAssignableFrom<IEnumerable<ToDoItemModel>>(okResult?.Value);

            Assert.Equal(3, buildings.Count());
        }

        [Fact]
        public async void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var notFoundResult = await _controller.GetToDoItemModel(-1);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            int id = 1;

            var okResult = await _controller.GetToDoItemModel(id);

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsRightBuilding()
        {
            int id = 1;

            var okResult = await _controller.GetToDoItemModel(id) as OkObjectResult;

            Assert.IsType<ToDoItemModel>(okResult?.Value);
            Assert.Equal(id, (okResult?.Value as ToDoItemModel)?.ItemId);
        }
    }
}