﻿using $ext_safeprojectname$.Controllers;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.ControllerTests.SitemapControllerTests
{
    public class BaseSitemapControllerTests
    {
        public BaseSitemapControllerTests()
        {
            FakeLogger = A.Fake<ILogger<SitemapController>>();
        }

        protected ILogger<SitemapController> FakeLogger { get; }

        protected SitemapController BuildSitemapController()
        {
            var controller = new SitemapController(FakeLogger)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext(),
                },
            };

            return controller;
        }
    }
}
