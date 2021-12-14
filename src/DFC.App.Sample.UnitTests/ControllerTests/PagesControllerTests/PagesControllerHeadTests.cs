using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace $safeprojectname$.ControllerTests.PagesControllerTests
{
    [Trait("Category", "Pages Controller - Head Unit Tests")]
    public class PagesControllerHeadTests : BasePagesControllerTests
    {
        [Theory]
        [MemberData(nameof(JsonMediaTypes))]
        [MemberData(nameof(HtmlMediaTypes))]
        public async Task PagesControllerHeadReturnsNoContentWhenNoData(string mediaTypeName)
        {
            // Arrange
            using var controller = BuildPagesController(mediaTypeName);

            // Act
            var result = await controller.Head("an-article").ConfigureAwait(false);

            // Assert
            var statusResult = Assert.IsType<NoContentResult>(result);

            A.Equals((int)HttpStatusCode.NoContent, statusResult.StatusCode);
        }
    }
}
