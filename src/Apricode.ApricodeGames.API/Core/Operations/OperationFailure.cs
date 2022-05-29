namespace Apricode.ApricodeGames.API.Core.Operations
{
    public class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string Code { get; set; } = String.Empty;
    }
}
