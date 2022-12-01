namespace ToDoApp.Domain.Generics
{
    public class Pagination<T>
    {
        public Pagination(IQueryable<T> content)
        {
            this.Content = content;
        }
        public int TotalCount = 200;
        public int PageSize = 5;
        public int TotalPage = 20;
        public IQueryable<T> Content { get; set; }
    }
}
