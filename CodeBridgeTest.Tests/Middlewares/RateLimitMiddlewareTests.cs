using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBridgeTest.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace CodeBridgeTest.Middlewares.Tests
{
    [TestClass()]
    public class RateLimitMiddlewareTests
    {
        private Mock<RequestDelegate> _mockRequestDelegate;
        private Mock<ILogger<RateLimitMiddleware>> _mockLogger;
        private RateLimitMiddleware _middleware;

        [TestInitialize]
        public void Initialize()
        {
            _mockRequestDelegate = new Mock<RequestDelegate>(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<RateLimitMiddleware>>();
            _middleware = new RateLimitMiddleware(_mockRequestDelegate.Object, _mockLogger.Object);

            _mockRequestDelegate.Setup(rd => rd(It.IsAny<HttpContext>())).Returns(Task.CompletedTask);
        }

        [TestMethod]
        public async Task InvokeAsync_Should_Set_Status_Code_429_When_Rate_Limit_Exceeded()
        {
            var context = new DefaultHttpContext();
            context.Connection.RemoteIpAddress = IPAddress.Parse("127.0.0.1");

            for (var i = 0; i < 11; i++)
            {
                await _middleware.InvokeAsync(context);
            }
            await _middleware.InvokeAsync(context);
            Assert.AreEqual(StatusCodes.Status429TooManyRequests, context.Response.StatusCode);
        }

        [TestMethod]
        public async Task InvokeAsync_Should_Not_Set_Status_Code_429_When_Rate_Limit_Not_Exceeded()
        {
            var context = new DefaultHttpContext();
            context.Connection.RemoteIpAddress = IPAddress.Parse("127.0.0.1");

            for (var i = 0; i < 10; i++)
            {
                await _middleware.InvokeAsync(context);
            }
            await _middleware.InvokeAsync(context);
            Assert.AreNotEqual(StatusCodes.Status429TooManyRequests, context.Response.StatusCode);
        }
    }
}