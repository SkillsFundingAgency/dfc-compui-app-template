﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Xunit;

namespace $safeprojectname$.ControllerTests.SitemapControllerTests
{
    [Trait("Category", "Sitemap Controller Unit Tests")]
    public class SitemapControllerViewTests : BaseSitemapControllerTests
    {
        [Fact]
        public void SitemapControllerViewReturnsSuccess()
        {
            // Arrange
            using var controller = BuildSitemapController();

            // Act
            var result = controller.SitemapView();

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);

            contentResult.ContentType.Should().Be(MediaTypeNames.Application.Xml);
        }
    }
}
