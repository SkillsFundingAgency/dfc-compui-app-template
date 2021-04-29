﻿using $safeprojectname$.Data.Models.ContentModels;
using $safeprojectname$.Extensions;
using $safeprojectname$.ViewModels;
using DFC.Compui.Cosmos.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    public class HealthController : Controller
    {
        public const string HealthViewCanonicalName = "health";

        private readonly ILogger<HealthController> logger;
        private readonly IDocumentService<SharedContentItemModel> sharedContentItemDocumentService;
        private readonly string resourceName = typeof(Program).Namespace!;

        public HealthController(ILogger<HealthController> logger, IDocumentService<SharedContentItemModel> sharedContentItemDocumentService)
        {
            this.logger = logger;
            this.sharedContentItemDocumentService = sharedContentItemDocumentService;
        }

        [HttpGet]
        [Route("pages/health")]
        public async Task<IActionResult> HealthView()
        {
            var result = await Health().ConfigureAwait(false);

            return result;
        }

        [HttpGet]
        [Route("health")]
        public async Task<IActionResult> Health()
        {
            logger.LogInformation("Generating Health report");

            var isHealthy = await sharedContentItemDocumentService.PingAsync().ConfigureAwait(false);

            if (isHealthy)
            {
                const string message = "Document store is available";
                logger.LogInformation($"{nameof(Health)} responded with: {resourceName} - {message}");

                var viewModel = CreateHealthViewModel(message);

                logger.LogInformation("Generated Health report");

                return this.NegotiateContentResult(viewModel, viewModel.HealthItems);
            }

            logger.LogError($"{nameof(Health)}: Ping to {resourceName} has failed");

            return StatusCode((int)HttpStatusCode.ServiceUnavailable);
        }

        [HttpGet]
        [Route("health/ping")]
        public IActionResult Ping()
        {
            logger.LogInformation($"{nameof(Ping)} has been called");

            return Ok();
        }

        private HealthViewModel CreateHealthViewModel(string message)
        {
            return new HealthViewModel
            {
                HealthItems = new List<HealthItemViewModel>
                {
                    new HealthItemViewModel
                    {
                        Service = resourceName,
                        Message = message,
                    },
                },
            };
        }
    }
}