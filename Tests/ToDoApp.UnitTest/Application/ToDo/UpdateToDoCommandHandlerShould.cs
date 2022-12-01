using AutoFixture.Xunit2;
using FluentAssertions;
using MediatR;
using Moq;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Commands.UpdateToDo;
using ToDoApp.Application.ToDo.Events;
using ToDoApp.Domain.Entities;
using Xunit;

namespace ToDoApp.UnitTests.Application.ToDo
{
    public class UpdateToDoCommandHandlerShould
    {
        [Theory]
        [AutoMoqData]
        public async Task UpdateStatusToDeletedAndPublishUpdateEvent(
            ToDoItem toDoItem,
            UpdateToDoCommand command,
            [Frozen] Mock<IToDoQueryRepository> queryRepositoryMock,
            [Frozen] Mock<IToDoCommandRepository> commandRepositoryMock,
            [Frozen] Mock<IMediator> mediator,
            UpdateToDoCommandHandler sut)
        {
            queryRepositoryMock.Setup(call => call.GetToDo(It.IsAny<Guid>(), It.IsAny<string>()))
                .ReturnsAsync(toDoItem);

            var result = await sut.Handle(command, CancellationToken.None);

            result.Should().Be(Unit.Value);
            commandRepositoryMock.Verify(
                call => call.UpdateToDo(It.Is<ToDoItem>(x =>
                    x.Status == command.Status && x.Description == command.Description)),
                Times.Once);
            mediator.Verify(call => call.Publish(It.IsAny<TaskUpdatedEvent>(), CancellationToken.None), Times.Once);
        }
    }
}
