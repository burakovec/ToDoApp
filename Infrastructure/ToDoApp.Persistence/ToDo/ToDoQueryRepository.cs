using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Persistence.ToDo
{
    public class ToDoQueryRepository : IToDoQueryRepository
    {
        private readonly ToDoDataContext _toDoDataContext;

        public ToDoQueryRepository(ToDoDataContext toDoDataContext)
        {
            _toDoDataContext = toDoDataContext;
            _toDoDataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public async Task<ToDoItem> GetToDo(Guid id, string username)
        {
            return await _toDoDataContext.ToDoItems.Where(x => x.Id.Equals(id) && x.Username.Equals(username)).SingleOrDefaultAsync();
        }

        public async Task<IQueryable<ToDoItem>> GetToDoList(string username)
        {
            return _toDoDataContext.ToDoItems.Where(x => x.Username.Equals(username)).Where(x => x.Status != Status.Deleted).AsQueryable();
        }
    }
}
