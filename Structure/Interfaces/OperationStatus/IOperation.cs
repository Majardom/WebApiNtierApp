namespace Structure.Interfaces.OperationStatus
{
    public interface IOperation
    {
        bool IsSuccessful { get; }
        string Message { get; }
    }
}
