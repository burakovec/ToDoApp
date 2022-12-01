using AutoFixture.Xunit2;
using FluentAssertions;
using MediatR;
using Moq;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Commands.DeleteToDo;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;
using Xunit;

namespace ToDoApp.UnitTests.Application.ToDo
{
    public class DeleteToDoCommandHandlerShould
    {
        [Theory]
        [AutoMoqData]
        public async Task UpdateStatusToDeleted(
            ToDoItem toDoItem,
            [Frozen] Mock<IToDoQueryRepository> queryRepositoryMock,
            [Frozen] Mock<IToDoCommandRepository> commandRepositoryMock,
            DeleteToDoCommandHandler sut)
        {
            var command = new DeleteToDoCommand(Guid.NewGuid().ToString(), "username");
            queryRepositoryMock.Setup(call => call.GetToDo(It.IsAny<Guid>(), It.IsAny<string>()))
                .ReturnsAsync(toDoItem);

            var result = await sut.Handle(command, CancellationToken.None);

            result.Should().Be(Unit.Value);
            commandRepositoryMock.Verify(call => call.UpdateToDo(It.Is<ToDoItem>(x => x.Status == Status.Deleted)),
                Times.Once);
        }
    }
}
