namespace ToDoApp.Domain.Generics
{
    public class Result<T> : Result
    {
        public T Payload { get; }

        protected internal Result(T payload)
            : base()
        {
            Payload = payload;
        }

        protected internal Result(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
