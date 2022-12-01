using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Queries;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;
using Xunit;

namespace ToDoApp.UnitTests.Application.ToDo
{
    public class GetToDoListQueryShould
    {
        [Theory]
        [AutoMoqData]
        public async Task ReturnUnitValueWhenSuccessful(
            GetToDoListQuery query,
            List<ToDoItem> toDoItems,
            [Frozen] Mock<IToDoQueryRepository> todoQueryRepositoryMock,
            GetTaskListQueryHandler sut)
        {
            var expectedItems = toDoItems.Where(x => x.Status != Status.Deleted).ToList();
            todoQueryRepositoryMock.Setup(call => call.GetToDoList(It.IsAny<string>())).ReturnsAsync(toDoItems);

            var result = await sut.Handle(query, CancellationToken.None);

            result.Should().BeEquivalentTo(expectedItems);
            todoQueryRepositoryMock.Verify(call => call.GetToDoList(It.IsAny<string>()), Times.Once);
        }
    }
}
