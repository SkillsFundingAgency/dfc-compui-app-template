using $ext_safeprojectname$.Data.Models.ContentModels;
using $ext_safeprojectname$.ViewModels;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace $safeprojectname$.ControllerTests.PagesControllerTests
{
    [Trait("Category", "Pages Controller Unit Tests")]
    public class PagesControllerIndexTests : BasePagesControllerTests
    {
        [Theory]
        [MemberData(nameof(HtmlMediaTypes))]
        public async Task PagesControllerIndexHtmlReturnsSuccess(string mediaTypeName)
        {
            // Arrange
            const int resultsCount = 2;
            var expectedResults = A.CollectionOfFake<SharedContentItemModel>(resultsCount);
            using var controller = BuildPagesController(mediaTypeName);

            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).Returns(expectedResults);
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).Returns(A.Fake<IndexDocumentViewModel>());

            // Act
            var result = await controller.Index().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).MustHaveHappened(resultsCount, Times.Exactly);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);

            A.Equals(resultsCount, model.Documents!.Count);
        }

        [Theory]
        [MemberData(nameof(JsonMediaTypes))]
        public async Task PagesControllerIndexJsonReturnsSuccess(string mediaTypeName)
        {
            // Arrange
            const int resultsCount = 2;
            var expectedResults = A.CollectionOfFake<SharedContentItemModel>(resultsCount);
            using var controller = BuildPagesController(mediaTypeName);

            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).Returns(expectedResults);
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).Returns(A.Fake<IndexDocumentViewModel>());

            // Act
            var result = await controller.Index().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).MustHaveHappened(resultsCount, Times.Exactly);

            var jsonResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(jsonResult.Value);

            A.Equals(resultsCount, model.Documents!.Count);
        }

        [Theory]
        [MemberData(nameof(HtmlMediaTypes))]
        public async Task PagesControllerIndexHtmlReturnsSuccessWhenNoData(string mediaTypeName)
        {
            // Arrange
            const int resultsCount = 0;
            IEnumerable<SharedContentItemModel>? expectedResults = null;
            using var controller = BuildPagesController(mediaTypeName);

            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).Returns(expectedResults);
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).Returns(A.Fake<IndexDocumentViewModel>());

            // Act
            var result = await controller.Index().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).MustHaveHappened(resultsCount, Times.Exactly);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);

            A.Equals(null, model.Documents);
        }

        [Theory]
        [MemberData(nameof(JsonMediaTypes))]
        public async Task PagesControllerIndexJsonReturnsSuccessWhenNoData(string mediaTypeName)
        {
            // Arrange
            const int resultsCount = 0;
            IEnumerable<SharedContentItemModel>? expectedResults = null;
            using var controller = BuildPagesController(mediaTypeName);

            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).Returns(expectedResults);
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).Returns(A.Fake<IndexDocumentViewModel>());

            // Act
            var result = await controller.Index().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).MustHaveHappened(resultsCount, Times.Exactly);

            var jsonResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(jsonResult.Value);

            A.Equals(null, model.Documents);
        }

        [Theory]
        [MemberData(nameof(InvalidMediaTypes))]
        public async Task PagesControllerIndexReturnsNotAcceptable(string mediaTypeName)
        {
            // Arrange
            const int resultsCount = 0;
            IEnumerable<SharedContentItemModel>? expectedResults = null;
            using var controller = BuildPagesController(mediaTypeName);

            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).Returns(expectedResults);
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).Returns(A.Fake<IndexDocumentViewModel>());

            // Act
            var result = await controller.Index().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeSharedContentItemDocumentService.GetAllAsync(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<IndexDocumentViewModel>(A<SharedContentItemModel>.Ignored)).MustHaveHappened(resultsCount, Times.Exactly);

            var statusResult = Assert.IsType<StatusCodeResult>(result);

            A.Equals((int)HttpStatusCode.NotAcceptable, statusResult.StatusCode);
        }
    }
}
