﻿using $ext_safeprojectname$.Data.Models.CmsApiModels;
using $ext_safeprojectname$.Data.Models.ContentModels;
using FakeItEasy;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace $safeprojectname$.WebhooksServiceTests
{
    [Trait("Category", "Webhooks Service ProcessContentAsync Unit Tests")]
    public class WebhooksServiceProcessContentAsyncTests : BaseWebhooksServiceTests
    {
        [Fact]
        public async Task WebhooksServiceProcessContentAsyncForCreateReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.Created;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            var expectedValidContentItemModel = BuildValidContentItemModel();
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel>(A<SharedContentItemApiDataModel>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeSharedContentItemDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeSharedContentItemDocumentService.UpsertAsync(A<SharedContentItemModel>.Ignored)).Returns(HttpStatusCode.Created);

            // Act
            var result = await service.ProcessContentAsync(url).ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel>(A<SharedContentItemApiDataModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.UpsertAsync(A<SharedContentItemModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessContentAsyncForUpdateReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.OK;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            var expectedValidContentItemModel = BuildValidContentItemModel();
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel>(A<SharedContentItemApiDataModel>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeSharedContentItemDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeSharedContentItemDocumentService.UpsertAsync(A<SharedContentItemModel>.Ignored)).Returns(HttpStatusCode.OK);

            // Act
            var result = await service.ProcessContentAsync(url).ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel>(A<SharedContentItemApiDataModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.UpsertAsync(A<SharedContentItemModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessContentAsyncForUpdateReturnsNoContent()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.NoContent;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            SharedContentItemModel? expectedValidContentItemModel = default;
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel?>(A<SharedContentItemApiDataModel>.Ignored)).Returns(expectedValidContentItemModel);

            // Act
            var result = await service.ProcessContentAsync(url).ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel>(A<SharedContentItemApiDataModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeSharedContentItemDocumentService.UpsertAsync(A<SharedContentItemModel>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessContentAsyncForUpdateReturnsBadRequest()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.BadRequest;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            var expectedValidContentItemModel = new SharedContentItemModel();
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel>(A<SharedContentItemApiDataModel>.Ignored)).Returns(expectedValidContentItemModel);

            // Act
            var result = await service.ProcessContentAsync(url).ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<SharedContentItemApiDataModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<SharedContentItemModel>(A<SharedContentItemApiDataModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeSharedContentItemDocumentService.UpsertAsync(A<SharedContentItemModel>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }
    }
}
