namespace ToDoApp.Domain.Generics
{
    public class Pagination 
    {
        public Pagination(IQueryable content)
        {
            this.Content = content;
        }
        public int TotalCount = 200;
        public int PageSize = 5;
        public int TotalPage = 20;
        public IQueryable Content { get; set; }
    }
}
