namespace Apricode.ApricodeGames.Core.Abstraction.Common
{
    public interface IOperationFailure
    {
        public string PropertyName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
    }
}
