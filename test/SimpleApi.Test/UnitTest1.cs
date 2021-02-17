using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Controllers;
using Xunit;

namespace SimpleApi.Test
{
    public class UnitTest1
    {
        NameController controller = new NameController();
        [Fact]
        public void GetReturnMyName()
        {
            var actionResult = controller.Get(0) as OkObjectResult;
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
            Assert.Equal("Ruslan", actionResult.Value as string);
        }
        [Fact]
        public void GetFailedReturn()
        {
            var actionResult = controller.Get(10);
            Assert.IsType<NotFoundResult>(actionResult);
            Assert.Equal(StatusCodes.Status404NotFound, (actionResult as NotFoundResult).StatusCode);
        }
        [Fact]
        public void GetReturnAllNames()
        {
            var actionResult = controller.Get() as OkObjectResult;
            string[] arr = new[] { "Ruslan", "Olga", "Ivan", "Sofia" };
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
            Assert.Equal(arr, actionResult.Value as string[]);
        }
        [Fact]
        public void GetSortArray()
        {
            var actionResult = controller.Sort() as OkObjectResult;
            string[] expected = new[] { "Ivan", "Olga", "Ruslan", "Sofia" };
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
            Assert.Equal(expected, actionResult.Value as string[]);
        }
    }
}
