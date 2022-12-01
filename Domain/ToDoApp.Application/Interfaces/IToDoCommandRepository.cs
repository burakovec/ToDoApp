
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoCommandRepository
    {
        Task CreateToDo(ToDoItem toDo);

        Task UpdateToDo(ToDoItem toDo);
    }
}
