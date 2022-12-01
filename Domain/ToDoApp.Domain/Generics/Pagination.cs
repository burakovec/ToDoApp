namespace ToDoApp.Domain.Generics
{
    public class Pagination 
    {
        public Pagination(IQueryable content)
        {
            this.content = content;
            this.TotalCount = 200;
            this.TotalPage = 20;
            this.PageSize = 5;
        } 
        public int TotalCount { get; set; }  
        public int PageSize { get; set; } 
        public int TotalPage { get; set; } 
        public IQueryable content { get; set; }
    }
}
