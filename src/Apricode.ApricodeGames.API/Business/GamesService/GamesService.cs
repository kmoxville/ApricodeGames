using Apricode.ApricodeGames.API.Core.Operations;

namespace Apricode.ApricodeGames.API.Business.GamesService
{
    public class GamesService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IOperationResult<GameItem>> CreateGameAsync(CreateGameItemRequest request)
        {
            var failures = new List<IOperationFailure>();
            GameItem gameItem = new GameItem();

            var devStudio = await _unitOfWork.DevelopmentStudios.GetAll()
                .FirstOrDefaultAsync(x => x.Id == request.DevepmentStudioId);

            if (devStudio == null)
                failures.Add(new OperationFailure() { Description = $"Studio with id {request.DevepmentStudioId} not found" });

            var genres = await _unitOfWork.Genres.GetAll()
                .Where(x => request.GenreIds.Contains(x.Id))
                .ToListAsync();

            if (genres.Count == 0)
                failures.Add(new OperationFailure() { Description = $"Wrong genres" });

            if (failures.Count > 0)
                return new OperationResult<GameItem>(gameItem, failures);

            gameItem.Title = request.Title;
            gameItem.DevelopmentStudio = devStudio!;
            gameItem.Genres = genres;

            try
            {
                await _unitOfWork.Games.InsertAsync(gameItem);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                failures.Add(new OperationFailure() { Description = ex.Message });
            }

            return new OperationResult<GameItem>(gameItem, failures); ;
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            try
            {
                _unitOfWork.Games.Delete(new GameItem() { Id = id });
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<GetGameItemsResponse> GetGamesAsync(int? skip, int? take, IEnumerable<int>? genreIds)
        {
            if (genreIds != null)
            {
                var query = _unitOfWork.GamesGenres.GetAll()
                    .Where(x => genreIds.Contains(x.GenreId));

                long totalCount = query.LongCount();

                var gameQuery = query.Skip(skip.GetValueOrDefault())
                    .Take(take.GetValueOrDefault())
                    .Include(x => x.GameItem).ThenInclude(x => x.Genres)
                    .Select(x => x.GameItem);

                return new GetGameItemsResponse()
                {
                    TotalCount = query.Count(),
                    Items = await gameQuery.AsNoTracking().ToListAsync()
                };
            }
            else
            {
                var query = _unitOfWork.Games.GetAll();

                long totalCount = query.LongCount();
                    
                query = query
                    .Skip(skip.GetValueOrDefault())
                    .Take(take.GetValueOrDefault());

                return new GetGameItemsResponse()
                {
                    TotalCount = totalCount,
                    Items = await query.AsNoTracking().ToListAsync()
                };
            }
        }

        public async Task<IOperationResult<GameItem>> UpdateGameAsync(UpdateGameItemRequest request)
        {
            var failures = new List<IOperationFailure>();

            var game = await _unitOfWork.Games.GetAll()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (game == null)
                failures.Add(new OperationFailure() { Description = $"Game with id {request.Id} not found"});

            var devStudio = await _unitOfWork.DevelopmentStudios.GetAll()
                .FirstOrDefaultAsync(x => x.Id == request.DevepmentStudioId);

            if (devStudio == null)
                failures.Add(new OperationFailure() { Description = $"Studio with id {request.DevepmentStudioId} not found" });

            var genres = await _unitOfWork.Genres.GetAll()
                .Where(x => request.GenreIds.Contains(x.Id)).ToListAsync();

            if (genres.Count == 0)
                failures.Add(new OperationFailure() { Description = $"Wrong genres" });

            if (failures.Count > 0)
                return new OperationResult<GameItem>(null, failures);

            game!.Title = request.Title;
            game!.DevelopmentStudio = devStudio!;
            game!.Genres = genres;

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                failures.Add(new OperationFailure() { Description = ex.Message });
            }

            return new OperationResult<GameItem>(game, failures);
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGamesService(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GamesService>();

            return services;
        }
    }
}
