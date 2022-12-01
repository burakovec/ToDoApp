namespace ToDoApp.Domain.Generics
{
    public class Result
    {
        public Result()
            : this(string.Empty)
        {
        }

        protected Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public bool IsSuccessful => string.IsNullOrEmpty(ErrorMessage);

        public static Result Fail(string errorMessage) => new Result(errorMessage);

        public static Result Ok() => new Result();

        public static Result<T> Fail<T>(string errorMessage)
        {
            return new Result<T>(errorMessage);
        }

        public static Result<T> Ok<T>(T payload)
        {
            return new Result<T>(payload);
        }
    }
}
