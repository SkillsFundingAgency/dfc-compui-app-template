using $safeprojectname$.Enums;
using System;
using System.Net;
using System.Threading.Tasks;

namespace $safeprojectname$.Contracts
{
    public interface IWebhooksService
    {
        Task<HttpStatusCode> ProcessMessageAsync(WebhookCacheOperation webhookCacheOperation, Guid eventId, Guid contentId, string apiEndpoint);
    }
}
