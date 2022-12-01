
using MediatR;

using Microsoft.Extensions.Logging;

namespace ToDoApp.Application.ToDo.Events
{
    public class TaskCompletedEventHandler : INotificationHandler<TaskUpdatedEvent>
    {
        private readonly ILogger<TaskCompletedEventHandler> _logger;

        public TaskCompletedEventHandler(ILogger<TaskCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(TaskUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(50, cancellationToken);
            _logger.LogInformation($"Sending email for user {notification.Email} with task {notification.Description} and status {notification.Status}.");
        }
    }
}
