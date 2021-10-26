using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using interview_yungching.Services;

namespace TestYungching
{
    [TestClass]
    public class UnitTest1
    {

        [Fact]
        public async Task TestCreateCustomer()
        {
            var test = new Mock<ICustomerService>();

            // Arrange
            //var mockRepo = new Mock<ICustomerDA>();
            //mockRepo.Setup(repo => repo.ListAsync())
            //    .ReturnsAsync(GetTestSessions());
            //var controller = new HomeController(mockRepo.Object);

            //// Act
            //var result = await controller.Index();

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(2, model.Count());
        }
    }
}
