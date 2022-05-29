using Apricode.ApricodeGames.API.Business.GamesService;
using Apricode.ApricodeGames.API.Controllers;
using Apricode.ApricodeGames.API.Core.Requests.GamesRequests;
using Apricode.ApricodeGames.API.Core.Responses.GamesResponses;
using Apricode.ApricodeGames.API.Data.Model;
using Apricode.ApricodeGames.API.Data.UnitOfWork;
using Apricode.ApricodeGames.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Apricode.ApricodeGames.UnitTests
{
    public class GamesControllerTest
    {
        [Fact]
        public async void GamesController_GetItems_ReturnsSuccess()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            var request = new GetGameItemsRequest();
            var unitOfWork = new UnitOfWork(new DatabaseContext(options));

            for (int i = 1; i < 50; i++)
                await unitOfWork.Games.InsertAsync(new GameItem() { Id = i });

            await unitOfWork.SaveAsync();

            var gameService = new GamesService(unitOfWork);
            var controller = new GamesController(gameService);

            var actionResult = await controller.GetItems(request);

            Assert.IsAssignableFrom<OkObjectResult>(actionResult);
        }
    }
}