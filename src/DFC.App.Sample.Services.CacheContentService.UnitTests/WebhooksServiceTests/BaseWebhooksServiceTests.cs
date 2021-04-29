﻿using $ext_safeprojectname$.Data.Models.CmsApiModels;
using $ext_safeprojectname$.Data.Models.ContentModels;
using DFC.Compui.Cosmos.Contracts;
using DFC.Content.Pkg.Netcore.Data.Contracts;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using System;

namespace $safeprojectname$.WebhooksServiceTests
{
    public abstract class BaseWebhooksServiceTests
    {
        protected const string EventTypePublished = "published";
        protected const string EventTypeDraft = "draft";
        protected const string EventTypeDraftDiscarded = "draft-discarded";
        protected const string EventTypeDeleted = "deleted";
        protected const string EventTypeUnpublished = "unpublished";

        protected BaseWebhooksServiceTests()
        {
            Logger = A.Fake<ILogger<WebhooksService>>();
            FakeMapper = A.Fake<AutoMapper.IMapper>();
            FakeCmsApiService = A.Fake<ICmsApiService>();
            FakeSharedContentItemDocumentService = A.Fake<IDocumentService<SharedContentItemModel>>();
        }

        protected Guid ContentIdForCreate { get; } = Guid.NewGuid();

        protected Guid ContentIdForUpdate { get; } = Guid.NewGuid();

        protected Guid ContentIdForDelete { get; } = Guid.NewGuid();

        protected ILogger<WebhooksService> Logger { get; }

        protected AutoMapper.IMapper FakeMapper { get; }

        protected ICmsApiService FakeCmsApiService { get; }

        protected IDocumentService<SharedContentItemModel> FakeSharedContentItemDocumentService { get; }

        protected static SharedContentItemApiDataModel BuildValidContentItemApiDataModel()
        {
            var model = new SharedContentItemApiDataModel
            {
                Title = "an-article",
                Url = new Uri("https://localhost"),
                Content = "some content",
                Published = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
            };

            return model;
        }

        protected SharedContentItemModel BuildValidContentItemModel()
        {
            var model = new SharedContentItemModel()
            {
                Id = ContentIdForUpdate,
                Etag = Guid.NewGuid().ToString(),
                Title = "an-article",
                Url = new Uri("https://localhost"),
                Content = "some content",
                LastReviewed = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                LastCached = DateTime.UtcNow,
            };

            return model;
        }

        protected WebhooksService BuildWebhooksService()
        {
            var service = new WebhooksService(Logger, FakeMapper, FakeCmsApiService, FakeSharedContentItemDocumentService);

            return service;
        }
    }
}
