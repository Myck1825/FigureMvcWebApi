using FigureMvcWebApi.Controllers;
using FigureMvcWebApi.Model.Constants;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using FigureMvcWebApi.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FigureMvcWebApi.Tests.Controllers
{
    [TestClass]
    public class FigureControllerTest
    {
        private readonly FigureController _controller;

        public FigureControllerTest() 
        {
            RectangeServiceStub rectangeServiceStub = new RectangeServiceStub();
            _controller = new FigureController(rectangeServiceStub);
        }

        [TestMethod]
        public void Rectangles()
        {
            // Arrange
            // Act
            ViewResult result = _controller.Rectangles() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Rectangles", result.ViewBag.Title);
        }

        [TestMethod]
        public void GetRectanglesAsync_PassRequestNull_ReturnArgumentNullException()
        {
            // Arrange
            // Act
            Func<Task> result = async () => await _controller.GetRectanglesAsync(null);

            // Assert
            var exception = Assert.ThrowsExceptionAsync<ArgumentNullException>(result);
            Assert.AreEqual(exception.Result.Message, ErrorMessages.ArgumentNullException);
        }

        [TestMethod]
        public async Task GetRectanglesAsync_ModelStateIsNotValid_ReturnModelStateDictionary()
        {
            // Arrange
            var request = new SegmentRequest();
            _controller.ModelState.AddModelError("test", "error");

            // Act
            var result = await _controller.GetRectanglesAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Data, typeof(ModelStateDictionary));
        }

        [TestMethod]
        public async Task GetRectanglesAsync_ModelStateIsValid_ReturnResult()
        {
            // Arrange
            var request = new SegmentRequest();
            _controller.ModelState.Clear();

            // Act
            var result = await _controller.GetRectanglesAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Data, typeof(FigureResponse));
        }
    }
}
