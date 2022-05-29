namespace Apricode.ApricodeGames.API.Business.GamesService
{
    public interface IGameService
    {
        Task<GetGameItemsResponse> GetGamesAsync(int? skip, int? take, IEnumerable<int>? genreIds);

        Task<IOperationResult<GameItem>> UpdateGameAsync(UpdateGameItemRequest request);

        Task<IOperationResult<GameItem>> CreateGameAsync(CreateGameItemRequest request);
        Task<bool> DeleteGameAsync(int id);
    }
}
