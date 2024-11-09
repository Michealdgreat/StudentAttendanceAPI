namespace Common.Application
{

    /// <summary>
    /// All return value with custom message without Data
    /// </summary>
    public class OperationResult
    {
        public const string SuccessMessage = "Operation Successful";
        public const string ErrorMessage = "An Error Occurred while processing your request";
        public const string NotFoundMessage = "Cannot retrieve data";
        public string? Message { get; set; }
        public OperationResultStatus Status { get; set; }

        public static OperationResult Success()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = SuccessMessage,
            };
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = message,
            };
        }

        public static OperationResult Error()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = ErrorMessage,
            };
        }
        public static OperationResult NotFound(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = message,
            };
        }
        public static OperationResult NotFound()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = NotFoundMessage,
            };
        }
        public static OperationResult Error(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = message,
            };
        }
        public static OperationResult Error(string message, OperationResultStatus status)
        {
            return new OperationResult()
            {
                Status = status,
                Message = message,
            };
        }

    }

    public enum OperationResultStatus
    {
        Error = 10,
        Success = 200,
        NotFound = 404
    }
}