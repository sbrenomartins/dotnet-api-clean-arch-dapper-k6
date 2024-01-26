namespace WebApi.Models.Error
{
    public class CustomValidationFailure
    {
        public CustomValidationFailure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }
    }
}
