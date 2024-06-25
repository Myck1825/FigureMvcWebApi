using FigureMvcWebApi;
using FigureMvcWebApi.Controllers;
using FigureMvcWebApi.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;
using System.Web.Mvc;
using FigureMvcWebApi.Tests.Stubs;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using System.Web.Http.Results;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;
using FigureMvcWebApi.Model;

namespace FigureMvcWebApi.Tests.Controllers
{
    [TestClass]
    public class FigureApiControllerTest
    {
        private readonly FigureApiController _controller;

        public FigureApiControllerTest()
        {
            RectangeServiceStub rectangeServiceStub = new RectangeServiceStub();
            _controller = new FigureApiController(rectangeServiceStub);
        }

        [TestMethod]
        public void GetListAsync_PassRequestNull_ReturnArgumentNullException()
        {
            // Arrange
            // Act
            Func<Task> result = async () => await _controller.GetListAsync(null);

            // Assert
            var exception = Assert.ThrowsExceptionAsync<ArgumentNullException>(result);
            Assert.AreEqual(exception.Result.Message, ErrorMessages.ArgumentNullException);
        }

        [TestMethod]
        public async Task GetListAsync_ModelStateIsNotValid_ReturnInvalidModelStateResult()
        {
            // Arrange
            var request = new SegmentRequest();
            _controller.ModelState.AddModelError("test", "error");

            // Act
            var result = await _controller.GetListAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public async Task GetListAsync_ModelStateIsValid_ReturnResult()
        {
            // Arrange
            var request = new SegmentRequest();
            _controller.ModelState.Clear();

            // Act
            var result = await _controller.GetListAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<AOResult<FigureResponse>>));
        }
    }
}
