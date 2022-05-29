using Apricode.ApricodeGames.API.Core.Operations;
using System.Net;

namespace Apricode.ApricodeGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Route("items")]
        [HttpPost]
        [ProducesResponseType(typeof(OperationResult<GameItem>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameItemRequest request)
        {
            var result = await _gameService.CreateGameAsync(request);

            if (!result.Succeed)
                return BadRequest(result);

            return CreatedAtAction(nameof(CreateGame), new { result.Result!.Id });
        }

        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(GetGameItemsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItems([FromQuery] GetGameItemsRequest request)
        {
            return Ok(await _gameService.GetGamesAsync(request.Skip, request.Take, request.GenreIds));
        }

        [Route("items")]
        [HttpPut]
        [ProducesResponseType(typeof(OperationResult<GameItem>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateGame([FromBody] UpdateGameItemRequest request)
        {
            var operationResult = await _gameService.UpdateGameAsync(request);

            if (!operationResult.Succeed)
                return NotFound(operationResult);

            return CreatedAtAction(nameof(UpdateGame), new { request.Id });
        }

        [Route("items/{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteGameAsync([FromRoute] int id)
        {
            if (await _gameService.DeleteGameAsync(id))
                return NoContent();

            return NotFound();
        }
    }
}
