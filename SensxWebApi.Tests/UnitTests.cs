using Microsoft.AspNetCore.Mvc;
using SensxWebApi.Controllers;
using SensxWebApi.Helper;
using Moq;
using Microsoft.AspNetCore.SignalR;
using SensxWebApi.Hub;
using SensxWebApi.Services;

namespace SensxWebApi.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Get_ReturnsOK_WhenNotificationsSent()
        {
            // Arrange
            var mockService = new Mock<INotificationService>();
            var controller = new SensxController(mockService.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void Reverse_ReturnsReversedString_WhenGivenString()
        {
            // Arrange
            string original = "Hello";
            string expected = "olleH";

            // Act
            string result = original.Reverse();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReverseString_ReturnsEmptyString_WhenGivenEmptyString()
        {
            // Arrange
            string original = "";
            string expected = "";

            // Act
            string result = original.Reverse();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReverseString_ReturnsException_WhenGivenNull()
        {
            // Arrange
            string original = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => original.Reverse());
        }
    }
}