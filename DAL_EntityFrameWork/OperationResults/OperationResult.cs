using Structure.Interfaces.OperationStatus;

namespace DAL_EntityFrameWork.OperationResults
{
    public class OperationResult : IOperation
    {
        public bool IsSuccessful { get; }
        public string Message { get; }

        public OperationResult(string message, bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
