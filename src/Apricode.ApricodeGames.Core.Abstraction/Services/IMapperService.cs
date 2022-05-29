namespace Apricode.ApricodeGames.Core.Abstraction.Services
{
    public interface IMapperService 
    {
        public TTarget Map<TTarget, TSource>(TSource source)
            where TTarget : class
            where TSource : class;
    }
}
