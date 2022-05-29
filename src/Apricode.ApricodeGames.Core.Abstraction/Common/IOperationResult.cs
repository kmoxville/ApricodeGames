namespace Apricode.ApricodeGames.Core.Abstraction.Common
{
    public interface IOperationResult<TResult>
        where TResult : class
    {
        TResult? Result { get; }

        IReadOnlyList<IOperationFailure> Failures { get; }

        bool Succeed { get; }
    }
}
