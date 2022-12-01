﻿
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoQueryRepository
    {
        Task<IQueryable<ToDoItem>> GetToDoList(string username);

        Task<ToDoItem> GetToDo(Guid id, string username);
    }
}
