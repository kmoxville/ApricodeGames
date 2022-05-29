namespace Apricode.ApricodeGames.API.Core.Operations
{
    public class OperationResult<TResult> : IOperationResult<TResult>
        where TResult : class
    {
        public IReadOnlyList<IOperationFailure> Failures { get; set; }

        public bool Succeed => Failures.Count == 0;

        public TResult? Result { get; set; }

        public OperationResult(TResult? result, IReadOnlyList<IOperationFailure> failures)
        {
            Failures = failures == null ? new List<IOperationFailure>() : failures;
            Result = result;
        }
    }
}
