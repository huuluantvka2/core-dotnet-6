using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces;
using UnitTest.MockData;
using WebApi.Controllers;

namespace UnitTest.System.Controllers
{
    public class TestFeedbackController
    {
        [Fact]
        public async Task GetFeedBacks_ShouldReturn200Status()
        {
            //Arrange
            var feedBackService = new Mock<IFeedbackService>();
            feedBackService.Setup(s => s.GetFeedBacks()).ReturnsAsync(FeedbackMockData.GetFeedBacks());
            var sut = new FeedbackController(feedBackService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetFeedBacks();

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetFeedBacks_ShouldReturn204Status()
        {
            //Arrange
            var feedBackService = new Mock<IFeedbackService>();
            feedBackService.Setup(s => s.GetFeedBacks()).ReturnsAsync(FeedbackMockData.GetFeedBacksEmpty());
            var sut = new FeedbackController(feedBackService.Object);

            //Act
            var result = (NoContentResult)await sut.GetFeedBacks();

            //Assert
            result.StatusCode.Should().Be(204);
            feedBackService.Verify(_ => _.GetFeedBacks(), Times.Exactly(1));
        }
    }
}
