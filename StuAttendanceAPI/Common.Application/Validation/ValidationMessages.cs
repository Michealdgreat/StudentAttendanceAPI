namespace Common.Application.Validation
{

    /// <summary>
    /// Used in command validator class
    /// provides message for the error in command parameters
    /// </summary>
    public static class ValidationMessages
    {
        public const string Required = "Field is required";
        public const string InvalidPhoneNumber = "Phone number not valid";
        public const string NotFound = "Requested data not found";
        public const string MaxLength = "Entered characters exceed the maximum limit";
        public const string MinLength = "Entered characters are less than the minimum limit";

        public static string required(string field) => $"{field} is required";
        public static string minLength(string field, int minLength) => $"{field} must be more than {minLength} characters";
    }
}