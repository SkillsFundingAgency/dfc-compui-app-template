﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Xunit;

namespace $safeprojectname$.ControllerTests.SitemapControllerTests
{
    [Trait("Category", "Sitemap Controller Unit Tests")]
    public class SitemapControllerSitemapTests : BaseSitemapControllerTests
    {
        [Fact]
        public void SitemapControllerSitemapReturnsSuccess()
        {
            // Arrange
            using var controller = BuildSitemapController();

            // Act
            var result = controller.Sitemap();

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);

            contentResult.ContentType.Should().Be(MediaTypeNames.Application.Xml);
        }
    }
}
